using System;

namespace HashTagProperty
{
    public class HashTagPropertyString
    {
 
        public string StorageString { get; private set; }

        public HashTagPropertyString() { }

        public HashTagPropertyString(string s)
        {
            StorageString = s;
        }

        public string GetHashTagPropertyValue(string name)
        {
            return StorageString.GetHashTagPropertyValue(name);
        }

        /// <summary>
        /// Adds a property to the property string or updates a property if it already exist
        /// </summary>
        public void AddUpdateHashTagProperty(string key, string value)
        {
            StorageString = StorageString.AddUpdateHashTagProperty(key, value.Replace("#", ""));
        }

        public void MergeHashTagPropertyString(string propertystring)
        {
            StorageString = StorageString.MergeHashTagPropertyString(propertystring);
        }

        public bool HasHashTagProperty(string name)
        {
            return StorageString.HasHashTagProperty(name);
        }

        public bool HasHashTagPropertyWithValue(string name, object value)
        {
            return StorageString.HasHashTagPropertyWithValue(name, value);
        }

        public int GetHashTagPropertyValueAsInt(string name)
        {
            return Convert.ToInt32(StorageString.GetHashTagPropertyValue(name));
        }

        public DateTime? GetHashTagPropertyValueAsDateTime(string name)
        {
            try
            {
                return Convert.ToDateTime(StorageString.GetHashTagPropertyValue(name));
            }
            catch { }

            return null;

        }
    }

   
}
