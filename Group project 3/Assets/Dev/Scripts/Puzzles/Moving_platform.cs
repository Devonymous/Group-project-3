using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    public Transform Target;
    public float speed = 3f;
    public bool Move = false;

    void Update()
    {
        if (Move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
        
        
    }
}
