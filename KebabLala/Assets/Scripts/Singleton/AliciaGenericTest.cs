using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton 
{
    public class AliciaGenericTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (AliciaGenericSingleton<AliciaGenericTest>.HasInstance)
            {
                Debug.Log("Singleton exists!");
            }
            else
            {
                Debug.Log("Singleton does not exist.");
            }


            AliciaSingleton.Instance.Operation("AliciaGenericTest");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
