using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Queue<string> sentences;

    public GameObject continueButton;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        sentences = new Queue<string>();
        
    }


    public void StartDialogue(Dialogue dialouge)
    {

        animator.SetBool("isOpen", true);

        sentences.Clear();

        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }



    public void EndDialouge()
    {
        Debug.Log("End of conversation");
        animator.SetBool("isOpen", false);
    }

}
