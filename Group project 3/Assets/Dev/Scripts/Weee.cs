using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weee : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    Vector3 test;
    GameObject Target;
    MeshRenderer rend;
    float change = 2,speed = 10,step;
    public Material[] colors = new Material[5];
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        test = new Vector3(Random.Range(-50,50),Random.Range(-50,50),Random.Range(-50,50));
        rb = GetComponent<Rigidbody>();
        Target = GameObject.FindGameObjectWithTag("Target");
        transform.position = new Vector3(Random.Range(-50,50),Random.Range(-50,50),Random.Range(-50,50));
        step = speed * Time.deltaTime;
        rend.material = colors[Random.Range(0,5)];
    }
    void Update()
    {
        Move();
        if (Time.time > change)
        {
            Change();
        }
        rb.angularVelocity = test;

    }
    void Move()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);
        if (transform.position == Target.transform.position)
        {
            transform.position = new Vector3(Random.Range(-50,50),Random.Range(-50,50),Random.Range(-50,50));
        }
    }
    void Change()
    {
        test = new Vector3(Random.Range(-50,50),Random.Range(-50,50),Random.Range(-50,50));
        change = Time.time + 2;
    }
}
