﻿using System.Collections.Generic;

namespace LiteJSON
{
    public class JsonObject
    {
        private Dictionary<string, object> _dict;

        public JsonObject()
        {
            _dict = new Dictionary<string, object>();
        }

        public void Put<T>(string key, T[] value)
        {
            if (value == null)
                _dict.Add(key, new JsonArray());
            else
                _dict.Add(key, JsonArray.FromArray(value));
        }

        public void Put<T>(string key, List<T> value)
        {
            if (value == null)
                _dict.Add(key, new JsonArray());
            else
                _dict.Add(key, JsonArray.FromList(value));
        }

        public void Put(string key, object value)
        {
            _dict.Add(key, value);
        }

        public T[] GetArray<T>(string key)
        {
            object obj = _dict[key];
            if(obj == null)
                return null;
            return ((JsonArray)obj).ToArray<T>();
        }

        public List<T> GetList<T>(string key)
        {
            object obj = _dict[key];
            if (obj == null)
                return null;
            return ((JsonArray)obj).ToList<T>();            
        }

        public object Get(string key)
        {
            return _dict[key];
        }

        public JsonObject GetJsonObject(string key)
        {
            return (JsonObject)_dict[key];
        }

        public int OptInt(string key, int defaultValue)
        {
            object result;
            if (_dict.TryGetValue(key, out result))
            {
                return (int)result;
            }
            return defaultValue;
        }

        public long OptLong(string key, long defaultValue)
        {
            object result;
            if (_dict.TryGetValue(key, out result))
            {
                return (long)result;
            }
            return defaultValue;
        }

        public bool OptBool(string key, bool defaultValue)
        {
            object result;
            if (_dict.TryGetValue(key, out result))
            {
                return (bool)result;
            }
            return defaultValue;
        }

        public string OptString(string key, string defaultValue)
        {
            object result;
            if (_dict.TryGetValue(key, out result))
            {
                return (string)result;
            }
            return defaultValue;
        }

        public float OptFloat(string key, float defaultValue)
        {
            object result;
            if (_dict.TryGetValue(key, out result))
            {
                return (float)result;
            }
            return defaultValue;
        }

        public double OptDouble(string key, double defaultValue)
        {
            object result;
            if (_dict.TryGetValue(key, out result))
            {
                return (double)result;
            }
            return defaultValue;
        }

        public int GetInt(string key)
        {
            return (int)_dict[key];
        }

        public long GetLong(string key)
        {
            return (long)_dict[key];
        }

        public bool GetBool(string key)
        {
            return (bool)_dict[key];
        }

        public string GetString(string key)
        {
            return (string)_dict[key];
        }

        public float GetFloat(string key)
        {
            object obj = _dict[key];
            if (obj is int)
                return (int)obj;
            else
                return (float)obj;
        }

        public double GetDouble(string key)
        {
            return (double)_dict[key];
        }

        public Dictionary<string, object>.KeyCollection Keys
        {
            get { return _dict.Keys; }
        }
    }
}

