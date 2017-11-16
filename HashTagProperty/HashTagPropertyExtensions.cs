using System;


namespace HashTagProperty
{
    public static class HashTagPropertyExtensions
    {
        public static HashTagPropertyString CreateHashTagPropertyString(this string propertystring)
        {
            return new HashTagPropertyString(propertystring);
        }

        public static string GetHashTagPropertyValue(this string s, string name)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            var arr = s.Split("#".ToCharArray());

            foreach (var pair in arr)
            {
                if (pair != string.Empty)
                {
                    var keyval = pair.Split("=".ToCharArray());
                    if (keyval.Length < 2)
                        return string.Empty;

                    if (keyval[0].ToUpper() == name.ToUpper())
                        return keyval[1];
                }
            }

            return string.Empty;
        }



        /// <summary>
        /// Adds a property to the property string or updates a property if it already exist
        /// </summary>
        public static string AddUpdateHashTagProperty(this string s, string key, string value)
        {
            var res = string.Empty;

            try
            {

                if (!string.IsNullOrEmpty(s))
                {
                    var arr = s.Split("#".ToCharArray());
                    foreach (String v in arr)
                    {
                        String[] keyval = v.Split("=".ToCharArray());
                        if (keyval[0].ToUpper() != key.ToUpper())
                        {
                            if (string.IsNullOrEmpty(res))
                                res = v;
                            else
                                res += "#" + v;
                        }
                    }
                }

                if (string.IsNullOrEmpty(res))
                    res = key + "=" + value;
                else
                    res += "#" + key + "=" + value;


            }
            catch { }

            return res;

        }

        /// <summary>
        /// Merge one property string in to another, by adding or update properties
        /// </summary>
        public static string MergeHashTagPropertyString(this string s, string propertystring)
        {
            var res = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(propertystring))
                {
                    var arr = propertystring.Split("#".ToCharArray());
                    foreach (String v in arr)
                    {
                        String[] key_and_val = v.Split("=".ToCharArray());
                        if (key_and_val == null)
                            continue;

                        if (key_and_val.Length != 2)
                            continue;

                        s = s.AddUpdateHashTagProperty(key_and_val[0], key_and_val[1]);
                    }

                }
            }
            catch { }

            return s;

        }

        public static bool HasHashTagProperty(this string s, string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(s))
                {
                    var arr = s.Split("#".ToCharArray());
                    foreach (var v in arr)
                    {
                        var keyval = v.Split("=".ToCharArray());
                        if (keyval[0].ToUpper() == key.ToUpper())
                            return true;
                    }
                }
            }
            catch { }

            return false;
        }

        public static bool HasHashTagPropertyWithValue(this string s, string name, object value)
        {
            var t = s.GetHashTagPropertyValue(name);
            if (string.IsNullOrEmpty(t))
                return false;

            var compare = string.Empty;
            if (value != null)
                compare = Convert.ToString(value);

            if (t == compare)
                return true;


            return false;
        }


    }
}
