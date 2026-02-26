using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;        // UI Text component
    public GameObject dialogueBox;   // UI Panel for dialogue
    private Queue<string> sentences; // Sentences in current dialogue

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(string[] dialogue)
    {
        dialogueBox.SetActive(true);
        sentences.Clear();
        foreach (string s in dialogue)
        {
            sentences.Enqueue(s);
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
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}