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
            if (gameObject.transform.position.y >= collision.transform.gameObject.transform.position.y)
            {
                
                Destroy(collision.transform.gameObject);
                rb.AddForce(transform.up * 500);
            }
            else
            {
                rb.AddForce(collision.transform.gameObject.transform.forward * 400 + transform.up * 400);
            }
        }
        if (collision.transform.gameObject.tag == "Boss")
        {
            if (gameObject.transform.position.y >= collision.transform.gameObject.transform.position.y)
            {
                collision.transform.gameObject.GetComponent<GenericAI>().DealDmg();
                rb.AddForce(transform.up * 500);
            }
            else
            {
                if (collision.transform.gameObject.GetComponent(typeof(ShoeAIScript)))
                {
                    collision.transform.gameObject.GetComponent<GenericAI>().DmgPlayer();
                    rb.AddForce(collision.transform.gameObject.transform.forward * 500 + transform.up * 500);
                }
                    
            }
        }
        if (collision.transform.gameObject.tag == "Attack")
        {
            collision.transform.gameObject.GetComponent<SoundBlip>().Sound();
            rb.AddForce(collision.transform.gameObject.transform.forward * 500 + transform.up * 500);
        }
    }
}
