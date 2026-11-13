using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioBank : MonoBehaviour
{
    [Serializable]
    public class SFX
    {
        public string name;
        public AudioClip sfx;
    }

    public SFX[] sfx;

    private void Start()
    {
        PlayLoop(1);
    }

    public void PlaySound(int id)
    {
        GetComponent<AudioSource>().PlayOneShot(sfx[id].sfx);
    }

    public void PlaySound(string id)
    {
        foreach(SFX s in sfx)
        {
            if(s.name == id)
                GetComponent<AudioSource>().PlayOneShot(s.sfx);
        }
    }
    
    public void PlayLoop(int id)
    {
        GetComponent<AudioSource>().clip = sfx[id].sfx;
        GetComponent<AudioSource>().Play();
    }

    public void PlayLoop(string id)
    {
        foreach (SFX s in sfx)
        {
            if (s.name == id)
                GetComponent<AudioSource>().clip = s.sfx;
                GetComponent<AudioSource>().Play();
        }
        
    }
}
