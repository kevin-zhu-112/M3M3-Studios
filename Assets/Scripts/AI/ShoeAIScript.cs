using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeAIScript : GenericAI
{
    public enum ShoeState
    {
        Idle,
        Chase,
        Hurt,
        Flank,
        Stomp
    }

    public ShoeState state;
    public GameObject player;
    public float fleeTime = 5.0f;
    public int moveSpeed = 4;
    public int health = 3;

    private AudioSource m_Audio;
    private Quaternion flankRotation;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        state = ShoeState.Chase;
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case ShoeState.Idle:
                //Do nothing for now
                break;
            case ShoeState.Chase:
                targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, 0, player.transform.position.z) - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.05f);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                break;
            case ShoeState.Hurt:
                targetRotation = Quaternion.LookRotation(transform.position - new Vector3(player.transform.position.x, 0, player.transform.position.z));
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.05f);
                transform.position += transform.forward * moveSpeed * 3 * Time.deltaTime;
                fleeTime -= Time.deltaTime;
                if (fleeTime <= 0.0f)
                {
                    state = ShoeState.Chase;
                }
                break;
            case ShoeState.Flank:
                transform.rotation = Quaternion.Lerp(transform.rotation, flankRotation, 0.2f);
                transform.position += transform.forward * moveSpeed * 3 * Time.deltaTime;
                fleeTime -= Time.deltaTime;
                if (fleeTime <= 0.0f)
                {
                    state = ShoeState.Chase;
                }
                break;
            default:
                break;
        }
    }

    public override void DealDmg()
    {
        if (state != ShoeState.Hurt)
        {
            m_Audio.Play(0);
            fleeTime = 5.0f;
            health--;
            if (health == 0) Destroy(this.gameObject);
            state = ShoeState.Hurt;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            flankRotation = transform.rotation * Quaternion.Euler(new Vector3(0, Random.Range(150f, 180f), 0));
            fleeTime += 0.5f;
            state = ShoeState.Chase;
        }
    }
}
