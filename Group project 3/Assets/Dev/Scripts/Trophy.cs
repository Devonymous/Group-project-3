using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    
    public NPC Person1,Person2,Person3;
    public GameObject trophy;
    void Update()
    {
        if (!trophy)
        {
            Person1.test2 = true;
            Person2.test2 = true;
            Person3.test2 = true;
        } 
    }
}
