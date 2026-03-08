using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnerText : MonoBehaviour
{
    // Note: Since this was a fun little add-on, this script is fully AI generated!
    public GameObject textPrefab;
    public RectTransform canvasRect;
    public Button[] buttonsToAvoid; // assign all buttons you want to avoid

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

        Vector2 pos;
        int attempts = 0;
        do
        {
            float randomX = Random.Range(-canvasRect.rect.width / 2, canvasRect.rect.width / 2);
            float randomY = Random.Range(-canvasRect.rect.height / 2, canvasRect.rect.height / 2);
            pos = new Vector2(randomX, randomY);

            attempts++;
            if (attempts > 20) break; // prevent infinite loop
        }
        while (IsOverlappingButton(pos, rect));

        rect.anchoredPosition = pos;
    }

    bool IsOverlappingButton(Vector2 pos, RectTransform textRect)
    {
        foreach (Button btn in buttonsToAvoid)
        {
            RectTransform btnRect = btn.GetComponent<RectTransform>();
            Vector2 localPoint = canvasRect.InverseTransformPoint(btn.transform.position);
            if (RectOverlaps(localPoint, btnRect.sizeDelta, pos, textRect.sizeDelta))
            {
                return true;
            }
        }
        return false;
    }

    bool RectOverlaps(Vector2 centerA, Vector2 sizeA, Vector2 centerB, Vector2 sizeB)
    {
        return Mathf.Abs(centerA.x - centerB.x) * 2 < (sizeA.x + sizeB.x) &&
               Mathf.Abs(centerA.y - centerB.y) * 2 < (sizeA.y + sizeB.y);
    }
}