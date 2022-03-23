using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    private GameObject NPC_Trigger;
    private bool Trigger;
    public GameObject NPC_text;
    public Animator animator;
    public GameObject Cam;
    
    void Update()
    {
        if(Trigger)
        {
            NPC_text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                var test = NPC_Trigger.GetComponent<NPC>();
                test.TriggerDialogue();
                
            }
        } else {
            NPC_text.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            Trigger = true;
            NPC_Trigger = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            Trigger = false;
            NPC_Trigger = null;
        }
    }

}
