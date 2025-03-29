using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource SFXsource;

    [Header("Audio Clip")]
    public AudioClip espresso_theme1;
    public AudioClip espresso_run;
    public AudioClip espresso_jump;
    public AudioClip espresso_runReverse;


    private void Start()
    {
        musicsource.clip = espresso_theme1;
        musicsource.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

}