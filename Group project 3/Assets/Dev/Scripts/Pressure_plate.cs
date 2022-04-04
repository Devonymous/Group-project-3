using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_plate : MonoBehaviour
{
    MeshRenderer boop;
    public Material mat;
    public Material matback;
    public int Test = 0;
    void Start()
    {
        boop = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            boop.material = matback;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Player")
        {
            boop.material = mat;
            Test++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Player")
        {
            boop.material = matback;
            Test--;
        }
    }

}
