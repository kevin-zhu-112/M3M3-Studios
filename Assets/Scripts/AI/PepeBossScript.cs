using UnityEngine;
using System.Collections;

public class PepeBossScript : GenericAI
{
    private UnityEngine.AI.NavMeshAgent agent;
    public ParticleSystem[] particles;
    public GameObject[] fleePoints;
    private GameObject fleePoint;
    private float startTime = 1.0f;
    private Rigidbody rb;
    public GameObject point;
    private Animator anim;
    public State state;
    public bool grounded = true;
    public float stunTime = 3.0f;
    public int health = 3;
    public GameObject stompAttack;
    public GameObject[] stompEffects;

    private AudioSource m_audio;
    public AudioClip hurt;
    public AudioClip blast;

    public enum State
    {
        Idle,
        Smash,
        Chase,
        Surround,
        Jumping,
        Stunned,
        Flee
    }

    void Start()
    {
        fleePoint = fleePoints[Random.Range(0, fleePoints.Length)];
        state = State.Chase;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        anim.SetBool("OnGround", grounded);
        if (!grounded)
        {
            anim.SetFloat("Jump", rb.velocity.y);
        }
        switch (state)
        {
            case State.Idle:
                break;
            case State.Chase:
                agent.SetDestination(point.transform.position);
                anim.SetFloat("Forward", agent.velocity.magnitude / agent.speed, .1f, Time.deltaTime);
                if (startTime > 0f)
                {
                    startTime -= Time.deltaTime;
                    break;
                }
                if (agent.remainingDistance < 1.5f)
                {
                    startTime = 1.0f;
                    agent.SetDestination(transform.position);
                    state = State.Smash;
                }
                break;
            case State.Smash:
                anim.SetFloat("Forward", 0);
                agent.enabled = false;
                rb.AddForce(transform.up * 4000);
                grounded = false;
                state = State.Jumping;
                break;
            case State.Jumping:
                Vector3 extraGravityForce = (Physics.gravity * 10f) - Physics.gravity;
                rb.AddForce(extraGravityForce);
                if (grounded)
                {
                    state = State.Stunned;
                }
                break;
            case State.Stunned:
                anim.SetBool("Crouch", true);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                if (stunTime < 0f)
                {
                    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    stunTime = 3.0f;
                    anim.SetBool("Crouch", false);
                    agent.enabled = true;
                    state = State.Chase;
                }
                stunTime -= Time.deltaTime;
                break;
            case State.Flee:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                stunTime = 3.0f;
                agent.enabled = true;
                agent.SetDestination(fleePoint.transform.position);
                anim.SetFloat("Forward", agent.velocity.magnitude / agent.speed, .1f, Time.deltaTime);
                if (agent.remainingDistance < 1)
                {
                    startTime = 1.0f;
                    state = State.Chase;
                }
                break;
            default:
                break;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (!grounded)
        {
            if (collision.transform.gameObject.tag == "Ground")
            {
                m_audio.clip = blast;
                m_audio.Play();
                var look = point.transform.position - transform.position;
                look.y = 0; 
                Instantiate(stompAttack, transform.position, Quaternion.LookRotation(look));
                Instantiate(stompEffects[0], transform.position, transform.rotation);
                Instantiate(particles[0], transform.position, transform.rotation);
                grounded = true;
            }
        }
        
    }

    public override void DealDmg()
    {
        if (state != State.Flee)
        {
            m_audio.clip = hurt;
            m_audio.Play();
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
            state = State.Flee;
            anim.SetBool("Crouch", false);
            fleePoint = fleePoints[Random.Range(0, fleePoints.Length)];
        }
    }
}