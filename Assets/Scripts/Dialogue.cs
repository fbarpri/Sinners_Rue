using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;   // assign your Canvas panel
    public TMP_Text dialogueText;      // TMP text inside panel
    public bool dialogueFinished = false;
    private PlayerInventory inventory;
    private PlayerMovement playerMovement;

    private Queue<string> sentences = new Queue<string>();

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Awake()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    public void StartDialogue(string[] dialogueLines)
    {
        if (dialogueLines.Length == 0)
        {
            return;
        }

        sentences.Clear();
        foreach (string s in dialogueLines)
            sentences.Enqueue(s);

        dialoguePanel.SetActive(true);
        playerMovement.StopMovement();
        playerMovement.enabled = false;
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
        dialogueFinished = true;
        dialoguePanel.SetActive(false);

        playerMovement.enabled = true;
        
        if (inventory.endGame)
        {
            SceneManager.LoadScene("End_Menu");
        }
    }
    public bool IsActive()
    {
        return dialoguePanel.activeSelf;
    }
}