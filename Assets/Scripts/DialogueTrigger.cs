using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void OnTriggerEnter(Collider c)
    {
        if (c.transform.gameObject.tag == "Player") {       
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
