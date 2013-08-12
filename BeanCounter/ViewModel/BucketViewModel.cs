using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using BeanCounter.Model;

namespace BeanCounter.ViewModel
{
    public class BucketViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private BucketDataContext bucketDB;

        // Class constructor, create the data context object.
        public BucketViewModel(string bucketDBConnectionString)
        {
            bucketDB = new BucketDataContext(bucketDBConnectionString);
        }

        // All bcket items.
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

        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            bucketDB.SubmitChanges();
        }


        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {
            // Specify the query for all buckets in the database.
            var bucketsInDB = from Bucket buckets in bucketDB.Buckets
                                select buckets;

            // Query the database and load all buckets.
            AllBuckets = new ObservableCollection<Bucket>(bucketsInDB);
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the app that a property has changed.
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
