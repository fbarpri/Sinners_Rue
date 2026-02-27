using UnityEngine;
using TMPro;

public class MenuTextSpawner : MonoBehaviour
{
    public GameObject textPrefab;
    public RectTransform canvasRect;

    public float spawnInterval = 3f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnText();
            timer = 0f;
        }
    }

    void SpawnText()
    {
        GameObject newText = Instantiate(textPrefab, canvasRect);

        RectTransform rect = newText.GetComponent<RectTransform>();

        float randomX = Random.Range(
            -canvasRect.rect.width / 2,
            canvasRect.rect.width / 2
        );

        float randomY = Random.Range(
            -canvasRect.rect.height / 2,
            canvasRect.rect.height / 2
        );

        rect.anchoredPosition = new Vector2(randomX, randomY);
    }
}