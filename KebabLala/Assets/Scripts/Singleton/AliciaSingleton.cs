using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    //Task1
    public class AliciaSingleton
    {
        private static AliciaSingleton instance;
        private string data;

        public static AliciaSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new AliciaSingleton("eiei");
                return instance;
            }
        }

        private AliciaSingleton(string data)
        {
            this.data = data;
        }

        public void Operation()
        {
            Debug.Log("cdsgetrh");
        }

        public void Operation(string msg)
        {
            Debug.Log($"calling from: {msg}");
        }
    }
}
