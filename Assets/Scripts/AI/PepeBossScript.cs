using UnityEngine;
using System.Collections;

public class PepeBossScript : GenericAI
{
    public State state;
    public bool grounded = true;
    public float stunTime;
    public int health;
    public GameObject stompAttack;
    public GameObject[] stompEffects;
    public GameObject[] particles;
    public GameObject[] fleePoints;
    public GameObject point;
    public GameObject shootAttack;
    public float cd;
    public Dialogue enragedDialogue;
    public Dialogue stunnedDialogue;

    private Rigidbody rb;
    private Animator anim;
    private int wayPoint = 0;
    private GameObject fleePoint;
    private float startTime = 1.0f;
    private UnityEngine.AI.NavMeshAgent agent;
    private bool enraged = false;
    private float times = 0f;

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
        Shoot,
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
                anim.SetFloat("Forward", 0);
                agent.enabled = false;
                anim.SetBool("Crouch", true);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                if (stunTime < 0f)
                {
                    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    anim.SetBool("Crouch", false);
                    agent.enabled = true;
                    if (enraged)
                    {
                        state = State.Shoot;
                        stunTime = 15.0f;
                    }
                    else
                    {
                        state = State.Chase;
                        stunTime = 7.5f;
                    }
                }
                stunTime -= Time.deltaTime;
                break;
            case State.Flee:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                agent.enabled = true;
                agent.SetDestination(fleePoint.transform.position);
                anim.SetFloat("Forward", agent.velocity.magnitude / agent.speed, .1f, Time.deltaTime);
                if (agent.remainingDistance < 1 && startTime <= 0)
                {
                    startTime = 1.0f;
                    if (enraged)
                    {
                        state = State.Shoot;
                        stunTime = 15.0f;
                    } else
                    {
                        state = State.Chase;
                        stunTime = 7.5f;
                    }
                    
                }
                startTime -= Time.deltaTime;
                break;
            case State.Shoot:
                if (agent.remainingDistance < 1)
                {
                    if (wayPoint % 2 == 0)
                    {
                        if (Random.Range(0f, 1f) < (0.1f * times))
                        {
                            FindObjectOfType<DialogueManager>().StartDialogue(stunnedDialogue);
                            state = State.Stunned;
                            times = 0;
                        } else
                        {
                            times += 1f;
                        }
                    }
                    if (Random.Range(-1.0f, 1.0f) < 0.0f)
                    {
                        wayPoint += 1;
                    } else
                    {
                        wayPoint -= 1;
                        if (wayPoint < 0) wayPoint = 7;
                    }
                    wayPoint = wayPoint % 8;
                    fleePoint = fleePoints[wayPoint];
                }
                if (cd <= 0)
                {
                    var look = point.transform.position - transform.position;
                    GameObject bullet = Instantiate(shootAttack, transform.position, Quaternion.LookRotation(look)) as GameObject;
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
                    cd = 0.5f;
                } else
                {
                    cd -= Time.deltaTime;
                }
                anim.SetFloat("Forward", agent.velocity.magnitude / agent.speed, .1f, Time.deltaTime);
                agent.speed = 10;
                agent.SetDestination(fleePoint.transform.position);
                break;
            default:
                break;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (!grounded)
        {
            if (collision.transform.gameObject.tag == "Ground" || collision.transform.gameObject.tag == "Placeable")
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
        if (state == State.Stunned)
        {
            m_audio.clip = hurt;
            m_audio.Play();
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
            if (health == 3)
            {
                enraged = true;
                FindObjectOfType<DialogueManager>().StartDialogue(enragedDialogue);
            }
            anim.SetBool("Crouch", false);
            fleePoint = fleePoints[Random.Range(0, fleePoints.Length)];
            state = State.Flee;
        }
    }
}