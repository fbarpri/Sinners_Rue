using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CandleLightFlip : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Light2D candleLight;

    private Vector3 originalLocalPosition;

    void Start()
    {
        originalLocalPosition = candleLight.transform.localPosition;
    }

    void Update()
    {
        if (spriteRenderer.flipX)
        {
            // Mirror X position
            candleLight.transform.localPosition = new Vector3(-originalLocalPosition.x, originalLocalPosition.y, originalLocalPosition.z);
        }
        else
        {
            candleLight.transform.localPosition = originalLocalPosition;
        }
    }
}