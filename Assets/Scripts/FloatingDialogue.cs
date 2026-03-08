using UnityEngine;
using TMPro;

public class HoverText : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, 0);
    public TextMeshProUGUI textUI;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }

    public void ShowText(string message)
    {
        textUI.text = message;
        textUI.gameObject.SetActive(true);
    }
}