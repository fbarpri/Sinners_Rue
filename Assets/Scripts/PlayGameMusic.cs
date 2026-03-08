using UnityEngine;

public class PlayGameMusic : MonoBehaviour {

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.instance.PlayGame();
        }
    }
}
