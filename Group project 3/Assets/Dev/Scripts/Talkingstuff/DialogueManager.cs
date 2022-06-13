using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text nametext;
    public Text dialoguetext;
    public Queue<string> sentences;
    public GameObject UI1;
    public GameObject Cam;
    public bool Istalking = false, Letters = false;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Istalking = true;
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
        if (!Letters)
        {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        } else 
        {
            StopAllCoroutines();
            dialoguetext.text = "";
            dialoguetext.text = sentences.ToString();
            Letters = false;
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialoguetext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Letters = true;
            dialoguetext.text += letter;
            yield return null;
        }
        Letters = false;
    }

    void EndDialogue()
    {
        Istalking = false;
        UI1.SetActive(true);
        Cam.SetActive(true);
        animator.SetBool("IsOpen", false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
