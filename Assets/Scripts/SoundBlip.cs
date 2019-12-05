using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBlip : MonoBehaviour
{
    private AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sound()
    {
        m_audio.Play();
    }
}
