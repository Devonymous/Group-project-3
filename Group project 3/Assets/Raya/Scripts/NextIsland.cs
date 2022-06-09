using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextIsland : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Touchingggg");
            CharacterController cc = col.GetComponent<CharacterController>();

            cc.enabled = false;
            col.transform.position = new Vector3(128, 245, -380);
            cc.enabled = true;
        }
    }
}
