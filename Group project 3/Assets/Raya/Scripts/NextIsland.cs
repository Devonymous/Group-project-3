using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextIsland : MonoBehaviour
{
    public Transform positionTeleport;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CharacterController cc = col.GetComponent<CharacterController>();

            cc.enabled = false;
            col.transform.position = positionTeleport.position;
            cc.enabled = true;
        }
    }
}
