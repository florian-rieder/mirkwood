using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource introMusic;
    public AudioSource bodyMusic;

    public float crossfadeDuration = 2.0f;

    private bool crossfading = false;
    private bool crossfaded = false; // Have we already switched to the main body of the music ?

    // Static instance of the singleton
    public static MusicController Instance;

    // Optional: Awake method to initialize the singleton
    private void Awake()
    {
        // If the instance does not exist, set it to this object
        if (Instance == null)
        {
            Instance = this;
            // Make sure the singleton persists between scene changes
        }
        else
        {
            // If an instance already exists and it's not this one, destroy this one
            Destroy(gameObject);
        }
    }



    void Start()
    {
        introMusic.Play();
    }

    public void Crossfade()
    {
        if (!crossfaded && !crossfading)
        {
            StartCoroutine(DoCrossfade());
        }
    }

    IEnumerator DoCrossfade()
    {
        crossfading = true;

        float timer = 0;
        float introVolume = introMusic.volume;
        float bodyVolume = bodyMusic.volume;

        bodyMusic.Play(); // Start playing body music before fading in

        while (timer < crossfadeDuration)
        {
            float t = timer / crossfadeDuration;
            introMusic.volume = Mathf.Pow(10, Mathf.Lerp(Mathf.Log10(introVolume), Mathf.Log10(0.001f), t));
            bodyMusic.volume = Mathf.Pow(10, Mathf.Lerp(Mathf.Log10(0.001f), Mathf.Log10(bodyVolume), t));
            timer += Time.deltaTime;
            yield return null;
        }

        introMusic.Stop();

        crossfading = false;
        crossfaded = true;
    }
}
