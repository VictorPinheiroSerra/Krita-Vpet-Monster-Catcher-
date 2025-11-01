using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [Serializable]
    public struct TPair
    {
        public TKey Key;
        public TValue Value;

        public TPair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    [SerializeField] List<TPair> pairs = new List<TPair>();
    Dictionary<TKey, TValue> dictionary;

    public Dictionary<TKey, TValue> Dictionary
    {
        get
        {
            if (dictionary == null)
                RebuildDictionary();
            return dictionary;
        }
    }

    private void RebuildDictionary()
    {
        dictionary = new Dictionary<TKey, TValue>();
        foreach (TPair pair in pairs)
        {
            if (!dictionary.ContainsKey(pair.Key))
                dictionary.Add(pair.Key, pair.Value);
            else
                Debug.LogWarning($"Duplicate key '{pair.Key}' found in SerializableDictionary.");
        }
    }

    public List<TKey> GetKeys() { return dictionary.Keys.ToList(); }
    public List<TValue> GetValues() { return dictionary.Values.ToList(); }
    public Dictionary<TKey, TValue> GetDictionary() { return dictionary;  }
}
