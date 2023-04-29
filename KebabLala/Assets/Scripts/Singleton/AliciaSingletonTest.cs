using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
//Task 1 and 3
    public class AliciaSingletonTest : AliciaGenericSingleton<AliciaSingletonTest>
    {
        private void Start()
        {
            AliciaSingleton.Instance.Operation();
        }
    }

}