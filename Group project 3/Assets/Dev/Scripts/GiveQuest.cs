using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour
{
    public Animator QuestAnim;
    public Text Questtext;
    public bool Quest1,Quest2,Quest3,Quest4,Quest5,Quest6;
    public GameObject[] Quest1Obj;
    bool endquest2 = false;
    public GiveQuest Lastquest;
    public NPC lastNPC;


    public void StartQuest()
    {
        if (Quest1)
        {
            QuestAnim.SetBool("IsOpen", true);
            Questtext.text = "Search 3 orbs";
            for (int i = 0; i < Quest1Obj.Length; i++)
            {
                Quest1Obj[i].SetActive(true);
            }
        }
        if (Quest2)
        {
            QuestAnim.SetBool("IsOpen", true);
            Questtext.text = "Find Himo Near the forest";
        }
        if (Quest3)
        {
            QuestAnim.SetBool("IsOpen", true);
            Questtext.text = "Finish the forest puzzle";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Quest3 && endquest2 == false)
        {
            QuestAnim.SetBool("IsOpen", false);
            endquest2 = true;
            Lastquest.Quest2 = false;
            lastNPC.test3 = true;
        }
    }
}

