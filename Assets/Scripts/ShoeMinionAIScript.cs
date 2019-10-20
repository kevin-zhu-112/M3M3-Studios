using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeMinionAIScript : MonoBehaviour
{
    public enum ShoeState
    {
        Idle,
        Chase
    }

    public ShoeState state;
    public GameObject player;
    public int speed;
    public int strength;

    AudioSource damnDaniel;
    float distToPlayer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        state = ShoeState.Idle;
        damnDaniel = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case ShoeState.Idle:
                //walk in circle
                transform.Rotate(0f, 1f, 0f);
                transform.position += transform.forward * speed * Time.deltaTime;

                distToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
                if (distToPlayer <= 7f)
                {
                    state = ShoeState.Chase;
                }
                break;

            case ShoeState.Chase:
                // Smoothly rotate towards the target point.
                var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
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
            if (player.transform.position.y >= gameObject.transform.position.y)
            {
                Destroy(gameObject);
            }
            else
            {
                //TODO: hurt player

                damnDaniel.Play();
                // Push player back
                player.GetComponent<Rigidbody>().AddForce(strength * transform.forward);
            }
        }
    }
}
