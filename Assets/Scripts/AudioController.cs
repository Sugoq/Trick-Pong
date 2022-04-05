using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [Header("Audio Clips")]
    public  AudioClip onWoodSound;
    public  AudioClip onCupBoundSound;
    public AudioClip waterSplashSound;

    [Header("Audio Sources")]
    public AudioSource[] sources;
    int currentIndex = 0;
    private void Awake()
    {
        
        instance = this;
    }
    // Update is called once per frame

  
    public void PlayOnWoodSound(float vol)
    {
        sources[currentIndex].PlayOneShot(onWoodSound,vol);
        currentIndex = (currentIndex + 1) % sources.Length;
        
    }
    public void PlayOnCupBoundSound()
    {
        sources[currentIndex].PlayOneShot(onCupBoundSound, 1.5f);
        currentIndex = (currentIndex + 1) % sources.Length;
    }
    public void PlayWaterSplashSound()
    {
        sources[currentIndex].PlayOneShot(waterSplashSound, 0.08f);
        currentIndex = (currentIndex + 1) % sources.Length;
    }
}
