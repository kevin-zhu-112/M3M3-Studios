using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSoundScript : MonoBehaviour
{
    public AudioClip slide;
    public AudioClip drop;
    private AudioSource m_audio;
    private Rigidbody rb;
    private bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.001f || Mathf.Abs(rb.velocity.z) > 0.001f)
        {
            if (!playing)
            {
                m_audio.clip = slide;
                m_audio.loop = true;
                playing = true;
                m_audio.Play();
            }
        }
        else
        {
            playing = false;
            m_audio.Stop();
        }
    }

    void OnCollisionStay(Collision c)
    {

    }

    void OnCollisionEnter(Collision c)
    {
        if (Mathf.Abs(rb.velocity.y) > 0.000001f)
        {
            m_audio.clip = drop;
            m_audio.loop = false;
            m_audio.Play();
        }
    }
}
