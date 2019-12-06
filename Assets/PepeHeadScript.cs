using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepeHeadScript : MonoBehaviour
{
    public enum PepeHeadState
    {
        Hidden,
        Unhiding,
        Chase
    }

    public PepeHeadState state;
    GameObject player;
    public float speed;
    public float attackRadius;
    public int turnSpeed;
    private Vector3 startPos;
    GameObject model;

    AudioSource m_audio;
    float distToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        transform.position += new Vector3(0, -3, 0);
        player = GameObject.FindWithTag("Player");
        state = PepeHeadState.Hidden;
        m_audio = GetComponent<AudioSource>();
        model = transform.GetChild(0).gameObject;
        model.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case PepeHeadState.Hidden:
                distToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
                if (distToPlayer <= attackRadius)
                {
                    model.SetActive(true);
                    state = PepeHeadState.Unhiding;
                }
                break;

            case PepeHeadState.Unhiding:
                if (transform.position.y < startPos.y)
                {
                    transform.position += new Vector3(0, .1f, 0);
                } else {
                    state = PepeHeadState.Chase;
                }
                break;

            case PepeHeadState.Chase:
                // Smoothly rotate towards the target point.
                var targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z) - transform.position); // we use gameObject's y value so that the shoe doesnt look up when the player jumps
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
                // move towards player
                transform.position += transform.forward * speed * Time.deltaTime;
                break;

            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
