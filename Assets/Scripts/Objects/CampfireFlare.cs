using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CampfireFlare : MonoBehaviour, InteractF
{
    [SerializeField] float boostedMin = 1.8f;
    [SerializeField] float boostedMax = 2.4f;
    [SerializeField] float duration = 2f;

    private FireFlicker flicker;

    void Start()
    {
        flicker = GetComponentInChildren<FireFlicker>();
    }

    public void InteractWithObjectF()
    {
        flicker.Flare(boostedMin, boostedMax, duration);
    }
}
