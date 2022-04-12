using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour
{
    public Animator QuestAnim;
    public Text Questtext;
    public bool Quest1,Quest2,Quest3,Quest4,Quest5,Quest6;
    
    public void StartQuest()
    {
        QuestAnim.SetBool("IsOpen",true);
        if (Quest1)
        {
            Questtext.text = "Search the forest";
        }
    }
}
