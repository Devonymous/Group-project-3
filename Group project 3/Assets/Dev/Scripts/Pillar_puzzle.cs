using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar_puzzle : MonoBehaviour
{
    MeshRenderer boop;
    public Material red,norm;
    void Start()
    {
        boop = this.GetComponent<MeshRenderer>();
        norm = boop.material;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pillar")
        {
            boop.material = red;
        }
    }
    void OnTriggerExit(Collider other)
    {
        boop.material = norm;
    }
}
