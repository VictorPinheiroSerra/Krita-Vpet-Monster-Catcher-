using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue> //pesquisar sobre SerializableCallback
{
    [SerializeField] List<TKey> keys;
    [SerializeField] List<TValue> values;
}
