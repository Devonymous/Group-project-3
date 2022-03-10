using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float start = 999999999999999999999999999999999999f;
    public float test;
    void Start()
    {
        start = Time.time + 5f;
    }

    void Update()
    {
        if (start < Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
