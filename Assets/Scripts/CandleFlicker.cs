using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CandleFlicker : MonoBehaviour
{
    private Light2D candleLight;

    void Start()
    {
        candleLight = GetComponent<Light2D>();
    }

    void Update()
    {
        candleLight.intensity = 2f + Mathf.PerlinNoise(Time.time * 5f, 0) * 1f; // base brightness + flicker time * variation in brightness
    }
}