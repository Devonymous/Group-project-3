using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talking : MonoBehaviour
{
    private GameObject NPC_Trigger;
    private bool Trigger;
    public GameObject NPC_text;
    public Animator animator,Char;
    public GameObject Cam;
    Text Show_text;
    
    void Update()
    {
        if(Trigger == true)
        {
            NPC_text.SetActive(true);
            Show_text = NPC_text.GetComponent<Text>();
            Show_text.text = "Talk";
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                var test = NPC_Trigger.GetComponent<NPC>();
                test.TriggerDialogue();
                Char.SetBool("IsWalking", false);
            }
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
            NPC_text.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
