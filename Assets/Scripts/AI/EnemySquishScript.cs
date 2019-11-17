using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquishScript : MonoBehaviour
{
    private GameObject upgradeManager;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upgradeManager = GameObject.Find("UpgradeManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Enemy")
        {
            Debug.Log(rb.velocity.y);
            if (gameObject.transform.position.y >= collision.transform.gameObject.transform.position.y)
            {
                
                Destroy(collision.transform.gameObject);
                rb.AddForce(transform.up * 500);
            }
            else
            {
                rb.AddForce(transform.forward * -400 + transform.up * 400);
            }
        }
        if (collision.transform.gameObject.tag == "Boss")
        {
            if (rb.velocity.y < -0.5)
            {
                Debug.Log("Hit");
                collision.transform.gameObject.GetComponent<ShoeAIScript>().DealDmg();
                rb.AddForce(transform.up * 500);
            }
            else
            {
                rb.AddForce(transform.forward * -500 + transform.up * 500);
            }
        }
    }
}
