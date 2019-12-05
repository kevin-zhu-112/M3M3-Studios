using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealDoor : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject door;

    private AudioSource m_Audio;
    private bool once = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (button1.GetComponent<DoubleButtonScript>().pressed && button2.GetComponent<ButtonPlaceable>().pressed) {
            door.SetActive(true);
            if (once) {
                m_Audio.Play(0);
                once = false;
            }   
        }
    }
}
