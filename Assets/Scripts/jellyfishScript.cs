using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyfishScript : MonoBehaviour
{
    AudioSource soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
            soundEffect.Play();
        if (collision.gameObject.tag == "Player")
        {

        }
    }


}
