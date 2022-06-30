using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AudioMixer audioMixer;
    [Tooltip("Time for music to fade in and out")]
    [SerializeField] private float fadeTime;

    [Header("Mixer Parameters")]
    [SerializeField] private string masterVolume = "MasterVolume";
    [SerializeField] private string musicVolume = "MusicVolume";
    [SerializeField] private string rainVolume = "RainVolume";
    [SerializeField] private string effectsVolume = "EffectsVolume";
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource rainSource;
    [SerializeField] private AudioSource effectsSource;

    [Header("Songs")]
    [SerializeField] private AudioClip menuSong;
    [SerializeField] private AudioClip chapter1Song;
    [SerializeField] private AudioClip chapter2Song;
    [SerializeField] private AudioClip chapter3Song;
    [SerializeField] private AudioClip chapter4Song;
    [SerializeField] private AudioClip chapter5Song;
    [SerializeField] private AudioClip chapter5SongPostDeath;

    [Header("SFX")]
    [SerializeField] private AudioClip rainSound;

    private float _masterVolume;
    private float _musicVolume;
    private float _rainVolume;
    private float _effectsVolume;

    private void Start()
    {
        _masterVolume = Mathf.Log10(1) * 20;
        _musicVolume = Mathf.Log10(1) * 20;
        _rainVolume = Mathf.Log10(1) * 20;
        _effectsVolume = Mathf.Log10(1) * 20;
        
        SetMasterVolume(_masterVolume);
        SetMusicVolume(_musicVolume);
        SetRainVolume(_rainVolume);
        SetEffectsVolume(_effectsVolume);
    }

    public void SetMasterVolume(float value)
    {
        _masterVolume = Mathf.Log10(value) * 20;
        audioMixer.SetFloat(masterVolume, _masterVolume);
    }
    
    public void SetMusicVolume(float value)
    {
        _musicVolume = Mathf.Log10(value) * 20;
        audioMixer.SetFloat(musicVolume, _musicVolume);
    }

    public void SetRainVolume(float value)
    {
        value = value * 0.3f;
        _rainVolume = Mathf.Log10(value) * 20;
        audioMixer.SetFloat(rainVolume, _rainVolume);
    }

    public void SetEffectsVolume(float value)
    {
        _effectsVolume = Mathf.Log10(value) * 20;
        audioMixer.SetFloat(effectsVolume, _effectsVolume);
    }

    public void PlaySoundEffect(AudioClip soundEffect)
    {
        effectsSource.clip = soundEffect;
        effectsSource.Play();
    } 

    public void StartChapterMusic(int chapter)
    {
        switch (chapter)
        {
            case 1:
                StartCoroutine(SwapMusic(chapter1Song));
                StartRainSound();
                break;
            
            case 2:
                StartCoroutine(SwapMusic(chapter2Song));
                break;

            case 3:
                StartCoroutine(SwapMusic(chapter3Song));
                break;

            case 4:
                StartCoroutine(SwapMusic(chapter4Song));
                break;

            case 5:
                StartCoroutine(SwapMusic(chapter5Song));
                break;

            default:
                break;
        }
    }

    public void StartSwapMusic(AudioClip newAudioClip)
    {
        StartCoroutine(SwapMusic(newAudioClip));
    }
    
    public void StartRainSound()
    {
        rainSource.Play();
    }

    public void StopRainSound()
    {
        StartCoroutine(FadeAndStopRain());
    }

    public IEnumerator FadeAndStopRain()
    {
        yield return StartCoroutine(StartFade(audioMixer, rainVolume, fadeTime, -80));
        rainSource.Stop();
        audioMixer.SetFloat(rainVolume, -10);
        yield break;
    }
    
    public IEnumerator SwapMusic(AudioClip newAudioClip)
    {
        yield return StartCoroutine(StartFade(audioMixer, musicVolume, fadeTime, -80));
        musicSource.clip = newAudioClip;
        audioMixer.SetFloat(musicVolume, _musicVolume);
        musicSource.Play();
        yield break;
    }
    
    public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }
}
