using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireFlicker : MonoBehaviour
{
    private Light2D flameLight;

    [Header("Flicker Settings")]
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 5.0f;

    private float baseMin;
    private float baseMax;

    void Start()
    {
        flameLight = GetComponent<Light2D>();
        baseMin = minIntensity;
        baseMax = maxIntensity;
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        flameLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }

    public void Flare(float boostedMin, float boostedMax, float duration)
    {
        StopAllCoroutines(); // cancel previous flare if active
        StartCoroutine(FlareRoutine(boostedMin, boostedMax, duration));
    }

    private IEnumerator FlareRoutine(float boostedMin, float boostedMax, float duration)
    {
        minIntensity = boostedMin;
        maxIntensity = boostedMax;

        yield return new WaitForSeconds(duration);

        minIntensity = baseMin;
        maxIntensity = baseMax;
    }
}
