using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject Player;
    public bool QuestGiver;
    public Dialogue dialogue;
    public GiveQuest questscript;
    public bool test2,test3,test4;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        if (QuestGiver)
        {
            questscript = gameObject.GetComponent<GiveQuest>();
            questscript.StartQuest();
        }
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (test2 == true)
        {
            dialogue.sentences = dialogue.sentences2;
        }
        if (test3 == true)
        {
            dialogue.sentences = dialogue.sentences3;
        }
        if (test4 == true)
        {
            dialogue.sentences = dialogue.sentences4;
        }
        if ((Player.transform.position-this.transform.position).sqrMagnitude<2.6*2.6) 
        {
            var lookPos = Player.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        } 
    }
}
