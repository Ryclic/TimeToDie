using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource me;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<AudioSource>();
        me.Play();
    }



    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
        me.volume = volume;
    }
}
