using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class AliciaMonoSingleton : MonoBehaviour
    {
        private static AliciaMonoSingleton instance;
        private string data;

        public static AliciaMonoSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<AliciaMonoSingleton>();
                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<AliciaMonoSingleton>();
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Operation()
        {
            Debug.Log("Operation called!");
        }
    }
}