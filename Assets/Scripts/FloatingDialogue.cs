using UnityEngine;
using TMPro;

public class HoverText : MonoBehaviour
{
    public Transform player;        // MC's transform
    public Vector3 offset = new Vector3(0, 2, 0); // above head
    public TextMeshProUGUI textUI;  // assign your TMP text in inspector

    void LateUpdate()
    {
        if (player != null)
            transform.position = player.position + offset;
    }

    // Call this when last sin is found
    public void ShowText(string message)
    {
        textUI.text = message;
        textUI.gameObject.SetActive(true);
    }
}