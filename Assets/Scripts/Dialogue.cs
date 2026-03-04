using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;   // assign your Canvas panel (Screen Space - Camera)
    public TMP_Text dialogueText;      // TMP text inside panel

    private Queue<string> sentences = new Queue<string>();

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(string[] dialogueLines)
    {
        if (dialogueLines.Length == 0) return;

        sentences.Clear();
        foreach (string s in dialogueLines)
            sentences.Enqueue(s);

        dialoguePanel.SetActive(true);
        DisplayNextSentence();
    }

    void Update()
    {
        if (!dialoguePanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DisplayNextSentence();
        }
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

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    // Allows other scripts (like PlayerMovement) to check if dialogue is open
    public bool IsActive()
    {
        return dialoguePanel.activeSelf;
    }
}