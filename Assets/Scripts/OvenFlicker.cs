using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OvenFlicker : MonoBehaviour
{
    private Light2D ovenLight;

    void Start()
    {
        ovenLight = GetComponent<Light2D>();
    }

    void Update()
    {
        ovenLight.intensity = 2f + Mathf.PerlinNoise(Time.time * 5f, 0) * 1f; // base brightness + flicker time * variation in brightness
    }
}