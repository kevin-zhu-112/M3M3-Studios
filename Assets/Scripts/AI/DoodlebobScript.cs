using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodlebobScript : MonoBehaviour
{
    public enum DoodlebobState
    {
        Attacking,
        Moving,
        Dead
    }

    public float spawnDelay = 2.5f; //time b/w obstacles spawn
    public GameObject[] obstacles = new GameObject[3]; //array that holds obstacls
    private float nextSpawnTime; 
    private int obstacleInd, randX;
    private Vector3 obstaclePos; //where obstacle will spawn
    public DoodlebobState currState = DoodlebobState.Attacking;
    public int health = 3;
    Vector3 destPos;
    private GameObject leftArm;
    private GameObject rightArm;
    AudioSource[] soundEffects = new AudioSource[2];
    AudioSource meHoyMinoy1, meHoyMinoy2;
    private GameObject levelDoor; 


    // Start is called before the first frame update
    void Start()
    {
        destPos = transform.position;
        leftArm = GameObject.Find("Doodlebob/LeftArm");
        rightArm = GameObject.Find("Doodlebob/RightArm");
        soundEffects = GetComponents<AudioSource>();
        meHoyMinoy1 = soundEffects[0];
        meHoyMinoy2 = soundEffects[1];
        levelDoor = GameObject.Find("Level Door");
        levelDoor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case DoodlebobState.Attacking:
                if (ShouldAttack())
                {
                    Attack();
                }

                if (transform.rotation.y > -.7071068)
                {
                    transform.Rotate(0, -5, 0);
                }
                break;

            case DoodlebobState.Moving:
                if (transform.position.z > destPos.z)
                {
                    transform.position -= new Vector3(0, 0, .5f);
                }
                else
                {
                    currState = DoodlebobState.Attacking;
                    leftArm.GetComponent<Animator>().SetBool("WaveArm", false);
                    rightArm.GetComponent<Animator>().SetBool("WaveArm", false);
                }

                if (transform.rotation.y < .7071068)
                {
                    transform.Rotate(0, 5, 0);
                }
                break;

            case DoodlebobState.Dead:
                //levelDoor.SetActive(true);
                Destroy(GameObject.Find("Kill Wall"));
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currState == DoodlebobState.Attacking && collision.gameObject.tag.Equals("Player"))
        {
            TakeDamage();
        }
    }

    //return true if obstacle shoud spawn
    private bool ShouldAttack()
    {
        return Time.time >= nextSpawnTime && currState == DoodlebobState.Attacking;
    }

    //spawns a random obstacle from obstacles[]
    private void Attack()
    {
        nextSpawnTime = Time.time + spawnDelay; //set next spawn time
        obstacleInd = Random.Range(0, 3); //choose random obstacle
        obstaclePos = transform.position; //set inital obstacle pos to doodlebob's pos

        if (obstacleInd == 0) //doodleSquid
        {
            obstaclePos.x = transform.position.x;
            obstaclePos.y = .5f;
            obstaclePos.z = transform.position.z;

            //starts the squidward in a random lane
            randX = Random.Range(0, 5);
            if (randX == 1)
            {
                obstaclePos.x += 1f;
            }
            else if (randX == 2)
            {
                obstaclePos.x += 2f;
            }
            else if (randX == 3)
            {
                obstaclePos.x -= 1f;
            }
            else if (randX == 4)
            {
                obstaclePos.x -= 2f;
            }
        }
        else if (obstacleInd == 1) //pineapple
        {
            obstaclePos.x = transform.position.x;
            obstaclePos.y = 1.2f;
            obstaclePos.z = transform.position.z;

            //starts the pineapple in a random lane
            randX = Random.Range(0, 3);
            if (randX == 0)
            {
                obstaclePos.x -= 1f;
            }
            else if (randX == 1)
            {
                obstaclePos.x += 1f;
            }
        }
        else if (obstacleInd == 2) //pencil
        {
            obstaclePos.x = transform.position.x + .25f;
            obstaclePos.y = .5f;
            obstaclePos.z = transform.position.z;
        }

        //actually spawn obstacle
        Instantiate(obstacles[obstacleInd], obstaclePos, new Quaternion(0, 0, 0, 0));
    }

    private void TakeDamage()
    {
        health--;

        leftArm.GetComponent<Animator>().SetBool("WaveArm", true);
        rightArm.GetComponent<Animator>().SetBool("WaveArm", true);
        currState = DoodlebobState.Moving;

        if (health == 2)
        {
            destPos = transform.position - new Vector3(0, 0, 25);
            spawnDelay = 1.75f;
            meHoyMinoy1.Play();
        }
        else if (health == 1)
        {
            destPos = transform.position - new Vector3(0, 0, 30);
            spawnDelay = 1.5f;
            meHoyMinoy2.Play();
        }
        else if (health == 0)
        {
            currState = DoodlebobState.Dead;
        }
    }
}