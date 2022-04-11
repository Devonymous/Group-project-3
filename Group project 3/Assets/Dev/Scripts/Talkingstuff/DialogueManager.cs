using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text nametext;
    public Text dialoguetext;
    private Queue<string> sentences;
    public GameObject UI1;
    public GameObject Cam;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        UI1.SetActive(false);
        Cam.SetActive(false);
        animator.SetBool("IsOpen", true);
        nametext.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialoguetext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialoguetext.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        UI1.SetActive(true);
        Cam.SetActive(true);
        animator.SetBool("IsOpen", false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
