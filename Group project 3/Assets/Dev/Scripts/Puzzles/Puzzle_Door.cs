using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Door : MonoBehaviour
{
    public Pillar_puzzle Plate1,Plate2;
    public Transform OpenPoint;
    float speed = 3f;
    // Update is called once per frame
    void Update()
    {
        if (Plate1.Pressed == true && Plate2.Pressed == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, OpenPoint.position, speed * Time.deltaTime);
        }
    }
}
