using UnityEngine;

public class CandleFlicker : MonoBehaviour
{
    private Light candleLight;

    void Start()
    {
        candleLight = GetComponent<Light>();
    }

    void Update()
    {
        candleLight.intensity = 2f + Mathf.PerlinNoise(Time.time * 5f, 0) * 0.4f;
    }
}