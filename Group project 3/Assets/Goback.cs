using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goback : MonoBehaviour
{
    public Transform spawn,player;
    public bool goback;

    void Update()
    {
        if (goback)
        {
            player.position = spawn.position;
        }
    }
    void OnTriggerEnter(Collider other)
    {
            goback = true;
    }
    void OnTriggerExit(Collider other)
    {
            goback = false;
    }
}
