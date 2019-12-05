using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private AudioSource m_Audio;
    private bool triggered = false;

    void Start()
    {
        m_Audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.gameObject.tag == "Player" && !triggered) {
            triggered = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            m_Audio.Play(0);
        }
    }
}
