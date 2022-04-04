using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_plate1 : MonoBehaviour
{
    MeshRenderer boop;
    public Material mat;
    public Material matback;
    public int Test;
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
