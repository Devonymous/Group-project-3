using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weee : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var Weee = new Vector3(5,3,2);
        rb.angularVelocity = Weee;
    }
}
