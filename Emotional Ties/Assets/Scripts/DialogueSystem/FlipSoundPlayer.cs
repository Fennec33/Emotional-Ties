using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource flipSound;

    [SerializeField] private float randomPitchRangeLow;
    [SerializeField] private float randomPitchRangeHigh;


    public void PlayFlipSound()
    {
        flipSound.pitch = Random.Range(randomPitchRangeLow, randomPitchRangeHigh);
        
        flipSound.Play();
    }
}
