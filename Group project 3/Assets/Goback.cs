using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goback : MonoBehaviour
{
    public Transform spawn,player;
    void Start()
    {
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        player.position = spawn.position;
    }
}
