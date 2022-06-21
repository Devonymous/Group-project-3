using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject wall1,wall2,wall3,wall4,Collect1,Collect2,Collect3;
    public Animator Quest;
    public NPC questnpc,nextnpc;
    public GiveQuest next,current;
    bool questend = false;


    // Update is called once per frame
    void Update()
    {
        if (!Collect1 && !Collect2 && !Collect3 && questend == false)
        {
            Destroy(wall1);
            Destroy(wall2);
            Destroy(wall3);
            Destroy(wall4);
            Quest.SetBool("IsOpen", false);
            questnpc.test2 = true;
            next.Quest2 = true;
            nextnpc.test2 = true;
            questend = true;
            current.Quest1 = false;
        }
    }
}
