using UnityEngine;

public class InteractBox : MonoBehaviour, Interactable  
{
    public GameObject eye;
    public GameObject textBox;

 public void Interact()
    {
    textBox.SetActive(!textBox.activeSelf);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetInteractable(this);
            eye.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetInteractable(null);
            eye.SetActive(false);
            textBox.SetActive(false);
        }
    }
}