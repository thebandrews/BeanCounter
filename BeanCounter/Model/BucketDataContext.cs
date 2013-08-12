using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace BeanCounter.Model
{

    public class BucketDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public BucketDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<Bucket> Buckets;
    }


    [Table]
    public class Bucket : INotifyPropertyChanged, INotifyPropertyChanging
    {

        // Define ID: private field, public property, and database column.
        private int _bucketItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int BucketItemId
        {
            get { return _bucketItemId; }
            set
            {
                if (_bucketItemId != value)
                {
                    NotifyPropertyChanging("BucketItemId");
                    _bucketItemId = value;
                    NotifyPropertyChanged("BucketItemId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _bucketName;

        [Column]
        public string BucketName
        {
            get { return _bucketName; }
            set
            {
                if (_bucketName != value)
                {
                    NotifyPropertyChanging("BucketName");
                    _bucketName = value;
                    NotifyPropertyChanged("BucketName");
                }
            }
        }

        // Define completion value: private field, public property, and database column.
        private int _beanCount;

        [Column]
        public int BeanCount
        {
            get { return _beanCount; }
            set
            {
                if (_beanCount != value)
                {
                    NotifyPropertyChanging("BeanCount");
                    _beanCount = value;
                    NotifyPropertyChanged("BeanCount");
                }
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }

}

