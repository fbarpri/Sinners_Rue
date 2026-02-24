using UnityEngine;

public class InteractBox : MonoBehaviour
{
    public GameObject eye;       // child object for the eye
    public GameObject textBox;   // TMP panel for dialogue
    public string message;       // optional message to show

    private bool playerInRange = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("PlayerInRange is true");
            playerInRange = true;
            eye.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("PlayerInRange is false");
            playerInRange = false;
            eye.SetActive(false);
            textBox.SetActive(false);
        }
    }

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            textBox.SetActive(!textBox.activeSelf);
        }
    }
}