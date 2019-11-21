using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButtonScript : MonoBehaviour
{
    private Animator m_Animator;
    private AudioSource m_Audio;
    public GameObject target;
    public GameObject otherButton;
    private GameObject presser;
    private bool pressed;
    private bool boxPressed;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = target.GetComponent<Animator>();
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (presser == null && boxPressed)
        {
            m_Animator.enabled = false;
            boxPressed = false;
            pressed = false;
        }
    }

    bool getPressed()
    {
        return pressed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player" || collision.transform.gameObject.tag == "Placeable")
        {
            pressed = true;
            if (collision.transform.gameObject.tag == "Placeable")
            {
                boxPressed = true;
                presser = collision.transform.gameObject;
            }

            if (otherButton.GetComponent<DoubleButtonScript>().getPressed())
            {
                m_Animator.enabled = true;
                m_Animator.SetTrigger("Move");
                m_Audio.Play(0);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Player")
        {
            m_Animator.enabled = false;
            pressed = false;
        }
    }
}