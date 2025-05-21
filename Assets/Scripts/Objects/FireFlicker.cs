using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireFlicker : MonoBehaviour
{
    Light2D flameLight;

    [Header("Flicker Settings")]
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 5.0f;

    void Start()
    {
        flameLight = GetComponent<Light2D>();
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        flameLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
