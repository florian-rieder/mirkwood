using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    public AudioClip[] walkSounds;
    public AudioSource audioSource;

    private CharacterController characterController;
    private float lastStepTime;
    private float minStepInterval = 0.1f; // Minimum step interval
    private float maxStepInterval = 1.0f; // Maximum step interval
    private float minPitch = 0.8f;
    private float maxPitch = 1.2f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    private void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.5)
        {
            // Calculate step interval based on velocity
            float stepInterval = Mathf.Lerp(maxStepInterval, minStepInterval, characterController.velocity.magnitude / 10f);

            if (Time.time > lastStepTime + stepInterval)
            {
                PlayFootstepSound();
                lastStepTime = Time.time;
            }
        }
    }

    private void PlayFootstepSound()
    {
        if (walkSounds.Length == 0 || audioSource == null)
            return;

        AudioClip clip = walkSounds[Random.Range(0, walkSounds.Length)];
        audioSource.clip = clip;
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
    }
}
