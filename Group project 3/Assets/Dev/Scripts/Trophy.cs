using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    
    public NPC Person1;
    public GameObject trophy;
    public GiveQuest Person1_;
    public Animator Quest;
    void Update()
    {
        if (!trophy)
        {
            Person1.test2 = true;
            Person1_.Quest3 = false;
            Quest.SetBool("IsOpen", false);
        } 
    }
}
