using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FurnaceFlicker : MonoBehaviour
{
    private Light2D furnaceLight;

    void Start()
    {
        furnaceLight = GetComponent<Light2D>();
    }

    void Update()
    {
        furnaceLight.intensity = 2f + Mathf.PerlinNoise(Time.time * 3f, 0) * 1.5f; // base brightness + flicker time * variation in brightness
    }
}