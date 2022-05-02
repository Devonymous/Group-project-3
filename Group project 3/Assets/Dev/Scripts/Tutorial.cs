using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject wall1,wall2,wall3,wall4,Collect1,Collect2,Collect3;


    // Update is called once per frame
    void Update()
    {
        if (!Collect1 && !Collect2 && !Collect3)
        {
            Destroy(wall1);
            Destroy(wall2);
            Destroy(wall3);
            Destroy(wall4);
        }
    }
}
