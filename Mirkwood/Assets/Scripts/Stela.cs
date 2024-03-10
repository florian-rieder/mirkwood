using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Easing;
using PixelCrushers.DialogueSystem;
using Cysharp.Threading.Tasks;

public class Stela : MonoBehaviour
{
    private bool active = false;
    public bool Active { get => this.active; }

    private bool collected = false;
    public bool Collected  { get => this.collected; }

    [SerializeField] private string variableName = "Stela1Active";

    Material emissiveMaterial; // Reference to the emissive material
    private Color startEmissionColor;
    [SerializeField] private float startIntensity = 0f;
    [SerializeField] private float endIntensity = 5f;
    [SerializeField] private float duration = 1f;
    [SerializeField] private AudioSource shimmerAudio;
    [SerializeField] private GameObject vanishAudioPrefab;
    private bool fading = false;
    float fadeDuration = 0.5f;


    Renderer rend;
    [SerializeField] private string emissiveMaterialName = "SteleGlow"; // Name of the emissive material
    float elapsedTime = 0f;

    public void Activate(bool value)
    {
        active = value;
        DialogueLua.SetVariable(variableName, value);
        //Debug.Log(DialogueLua.GetVariable(variableName).AsBool);
        shimmerAudio.Play();
    }

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Find the emissive material by name
        foreach (Material mat in rend.materials)
        {
            if (mat.name.Contains(emissiveMaterialName))
            {
                emissiveMaterial = mat;
                break;
            }
        }

        if (emissiveMaterial == null)
        {
            Debug.LogError("Emissive material not found!");
            return;
        }

        startEmissionColor = emissiveMaterial.GetColor("_EmissionColor");

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
            //Debug.Log(intensity);
        }
    }

    public async void Disappear()
    {
        MusicController.Instance.Crossfade();

        StelaManager.Instance.ActivateNextStela();
        
        await FadeShimmer();

        var vanishAudio = Instantiate(vanishAudioPrefab).GetComponent<AudioSource>();
        Vector3 currPos = transform.position;
        currPos.y = 1.5f;
        vanishAudio.transform.position = currPos;
        vanishAudio.Play();

        // Spawn particles here
        // TODO: Spawn indicator of direction of the next stela


        await UniTask.Delay(TimeSpan.FromSeconds(1.6f), ignoreTimeScale: false);

        
        gameObject.SetActive(false);
    }

    void SetEmission(Color color, float intensity)
    {
        // Create a new color with specified intensity
        Color finalColor = color * intensity;

        // Set the emission color of the material
        emissiveMaterial.SetColor("_EmissionColor", finalColor);

        // Enable emission on the material
        //rend.material.EnableKeyword("_EMISSION");
    }

    IEnumerator FadeShimmer()
    {
        fading = true;

        float timer = 0;
        float volume = shimmerAudio.volume;

        while (timer < fadeDuration)
        {
            float t = timer / fadeDuration;
            shimmerAudio.volume = Mathf.Pow(10, Mathf.Lerp(Mathf.Log10(volume), Mathf.Log10(0.001f), t));
            timer += Time.deltaTime;
            yield return null;
        }

        fading = false;
    }
}
