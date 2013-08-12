using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using BeanCounter.Model;

namespace BeanCounter.ViewModel
{
    public class BucketViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// LINQ to SQL data context for the local database.
        /// </summary>
        private BucketDataContext bucketDB;

        /// <summary>
        /// Class constructor, create the data context object.
        /// </summary>
        /// <param name="bucketDBConnectionString"></param>
        public BucketViewModel(string bucketDBConnectionString)
        {
            bucketDB = new BucketDataContext(bucketDBConnectionString);
        }

        /// <summary>
        /// All bucket items.
        /// </summary>
        private ObservableCollection<Bucket> _allBuckets;
        public ObservableCollection<Bucket> AllBuckets
        {
            get { return _allBuckets; }
            set
            {
                _allBuckets = value;
                NotifyPropertyChanged("AllBuckets");
            }
        }

        /// <summary>
        /// Write changes in the data context to the database.
        /// </summary>
        public void SaveChangesToDB()
        {
            bucketDB.SubmitChanges();
        }


        /// <summary>
        /// Query database and load the collections.
        /// </summary>
        public void LoadCollectionsFromDatabase()
        {
            // Specify the query for all buckets in the database.
            var bucketsInDB = from Bucket buckets in bucketDB.Buckets
                                select buckets;

            // Query the database and load all buckets.
            AllBuckets = new ObservableCollection<Bucket>(bucketsInDB);
        }

        /// <summary>
        /// Add a bucket item to the database and collections.
        /// </summary>
        /// <param name="newBucket"></param>
        public void AddBucket(Bucket newBucket)
        {
            // Add a bucket item to the data context.
            bucketDB.Buckets.InsertOnSubmit(newBucket);

            // Save changes to the database.
            bucketDB.SubmitChanges();

            // Add a bucket item to the "all" observable collection.
            AllBuckets.Add(newBucket);            
        }

        /// <summary>
        /// Remove a bucket item from the database and collections.
        /// </summary>
        /// <param name="toDoForDelete"></param>
        public void DeleteBucket(Bucket bucketForDelete)
        {
            // Remove the bucket item from the "all" observable collection.
            AllBuckets.Remove(bucketForDelete);

            // Remove the bucket item from the data context.
            bucketDB.Buckets.DeleteOnSubmit(bucketForDelete);

            // Save changes to the database.
            bucketDB.SubmitChanges();
        }

        public void UpdateBucket(string name, int count)
        {
            foreach (Bucket bucket in AllBuckets)
            {
                if (bucket.BucketName == name)
                {
                    bucket.BeanCount = count;
                }                
            }

            // Save changes to the database.
            bucketDB.SubmitChanges();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Used to notify the app that a property has changed.
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
