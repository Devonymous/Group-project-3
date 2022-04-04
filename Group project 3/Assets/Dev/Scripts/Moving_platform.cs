using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    public Transform Point1,Point2;
    public float speed = 1f;
    bool Go1 = true,Go2 = false;

    void Update()
    {
        if (transform.position.x == Point1.position.x)
        {
            Go1 = false;
            Go2 = true;
        }
        if (transform.position.x == Point2.position.x)
        {
            Go1 = true;
            Go2 = false;
        }
        if (Go1 == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point1.position, speed * Time.deltaTime);
        }
        if (Go2 == true) 
        {
            transform.position = Vector3.MoveTowards(transform.position, Point2.position, speed * Time.deltaTime);
        }
        
    }
}
