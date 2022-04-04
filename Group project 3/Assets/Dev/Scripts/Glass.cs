using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public int test1,test2;
    public GameObject pad1,pad2;
    public GameObject NPC;

    void Update()
    {
        test1 = pad1.GetComponent<Pressure_plate>().Test;
        test2 = pad2.GetComponent<Pressure_plate1>().Test;
        if (test1 + test2 == 2) 
        {
            NPC.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
