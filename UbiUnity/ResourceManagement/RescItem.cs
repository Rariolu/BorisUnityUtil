using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UbiUnity.ResourceManagement
{
    /// <summary>
    /// A class which specifies a particular resource
    /// and gives it a designated name.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class RescItem<T>
    {
        [SerializeField]
        public string Name;
        [SerializeField]
        public T Item;
    }

    /// <summary>
    /// A struct used to identify specific instances of "RescItem"
    /// inside the ResourceManager.
    /// </summary>
    struct RescItemKey
    {
        string strKey;
        Type type;
        public RescItemKey(string key, Type t)
        {
            strKey = key;
            type = t;
        }
    }
}