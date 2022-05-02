using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_plate1 : MonoBehaviour
{
    public MeshRenderer boop;
    public GameObject wall;
    public Material mat;
    public Material matback;
    public int Test;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            boop.material = matback;
        }
        if (!wall)
        {
            boop.material = mat;
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
