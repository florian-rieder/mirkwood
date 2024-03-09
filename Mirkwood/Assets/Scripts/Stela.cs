using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easing;

public class Stela : MonoBehaviour
{
    private bool active = false;
    public bool Active { get => this.active; }

    private bool collected = false;
    public bool Collected  { get => this.collected; }

    
    private Color startEmissionColor;
    [SerializeField] private float startIntensity = 0f;
    [SerializeField] private float endIntensity = 5f;
    [SerializeField] private float duration = 1f;


    public void Activate(bool value)
    {
        active = value;
    }

    Renderer rend;
    float elapsedTime = 0f;

    void Start()
    {
        rend = GetComponent<Renderer>();

        startEmissionColor = rend.materials[1].GetColor("_EmissionColor");

        // Set the initial emission color and intensity
        SetEmission(startEmissionColor, startIntensity);
    }

    void Update()
    {
        if (active && elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float intensity = Ease.QuadInOut(startIntensity, endIntensity, t);
            SetEmission(startEmissionColor, intensity);
            Debug.Log(intensity);
        }
    }

    void SetEmission(Color color, float intensity)
    {
        // Create a new color with specified intensity
        Color finalColor = color * intensity;

        // Set the emission color of the material
        rend.materials[1].SetColor("_EmissionColor", finalColor);

        // Enable emission on the material
        //rend.material.EnableKeyword("_EMISSION");
    }
}
