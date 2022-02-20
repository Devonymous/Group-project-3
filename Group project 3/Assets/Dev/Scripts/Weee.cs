using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weee : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    Vector3 test;
    GameObject Target,cam;
    MeshRenderer rend;
    [SerializeField] float change = 2,speed = 5,step,scalesize;
    public Material[] colors = new Material[5];
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
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
        scalesize = Target.transform.localScale.x;
        speed = (scalesize / 2) + 3;
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
            cam.transform.position -= new Vector3(0,0,0.05f);
            Target.transform.localScale += new Vector3(0.05f,0.05f,0.05f);
            transform.position = new Vector3(Random.Range(-50 - scalesize, 50  + scalesize), Random.Range(-50 - scalesize, 50  + scalesize), Random.Range(-50 - scalesize, 50  + scalesize));
        }
    }
    void Change()
    {
        test = new Vector3(Random.Range(-50,50),Random.Range(-50,50),Random.Range(-50,50));
        change = Time.time + 2;
    }
}
