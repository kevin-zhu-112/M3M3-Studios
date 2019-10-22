using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private Animator m_Animator;
    private AudioSource m_Audio;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = target.GetComponent<Animator>();
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            m_Animator.SetTrigger("Move");
            m_Audio.Play(0);
        }
    }
}
