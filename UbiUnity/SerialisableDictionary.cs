using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UbiUnity
{
    [Serializable]
    public class SerialisableDictionary<T,U> : Dictionary<T,U>
    {
        public DictStruct<T, U>[] values;

        /// <summary>
        /// Stores the elements in "values".
        /// </summary>
        public void StoreGivenValues()
        {
            foreach(DictStruct<T,U> val in values)
            {
                if (!ContainsKey(val.Key))
                {
                    Add(val.Key, val.Value);
                }
                else
                {
                    
                }
            }
        }
    }

    [Serializable]
    public struct DictStruct<T,U>
    {
        public T Key;
        public U Value;
    }
}
