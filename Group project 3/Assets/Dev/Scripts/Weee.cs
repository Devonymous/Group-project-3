using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weee : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    Vector3 test;
    GameObject Target;
    float change = 2;
    float speed = 10;
    float step;
    void Start()
    {
        test = new Vector3(Random.Range(-50,50),Random.Range(-50,50),Random.Range(-50,50));
        rb = GetComponent<Rigidbody>();
        Target = GameObject.FindGameObjectWithTag("Target");
        transform.position = new Vector3(Random.Range(-50,50),Random.Range(-50,50),Random.Range(-50,50));
        step = speed * Time.deltaTime;
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
