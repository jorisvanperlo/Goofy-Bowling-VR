using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to store the 4 audio clips
    public AudioSource audioSource; // AudioSource to play the clips

    private int currentClipIndex = 0; // Index of the current audio clip

    void Start()
    {
        if (audioClips.Length > 0 && audioSource != null)
        {
            PlayNextClip();
        }
        else
        {
            Debug.LogError("AudioClips or AudioSource not assigned!");
        }
    }

    void Update()
    {
        // Check if the AudioSource is not playing
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        // Play the current clip
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();

        // Move to the next clip (looping back to the start if needed)
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
    }
}
