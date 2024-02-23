using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace ALS.BohlPon
{
    [System.Serializable]
    public class CustomData
    {
        public string ID;
        public int Quantity;
    }

    public class OdinTesting : SerializedMonoBehaviour
    {
        public Dictionary<int, CustomData> MyDictionary = new(); //new Dictionary<string, int>();
        public string ButtonName = "Dynamic button name";
        public bool Toggle;

        [Button("$ButtonName")]
        private void DefaultSizedButton()
        {
            this.Toggle = !this.Toggle;
        }
    }
}