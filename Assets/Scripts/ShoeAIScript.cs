using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeAIScript : MonoBehaviour
{
    public enum ShoeState
    {
        Idle,
        Chase,
        Hurt,
        Stomp
    }

    public ShoeState state;
    public GameObject player;
    public float fleeTime = 5.0f;
    public int moveSpeed = 4;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        state = ShoeState.Chase;
        DealDmg();
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
                transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                Debug.Log("Chasing");
                break;
            case ShoeState.Hurt:
                transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(player.transform.position.x, 0, player.transform.position.z));
                transform.position += transform.forward * moveSpeed * 2 * Time.deltaTime;
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

    public void DealDmg()
    {
        if (state != ShoeState.Hurt)
        {
            fleeTime = 5.0f;
            health--;
            if (health == 0) Destroy(this.gameObject);
            state = ShoeState.Hurt;
        }
    }
}
