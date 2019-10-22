using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquishScript : MonoBehaviour
{
    private GameObject upgradeManager;

    // Start is called before the first frame update
    void Start()
    {
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
            if (collision.collider.GetType() == typeof(SphereCollider))
            {
                Debug.Log("Hit");
                Destroy(collision.transform.gameObject);
                upgradeManager.GetComponent<UpgradeController>().GainDoubleJump();
            }
            else
            {
                // Receive dmg
            }
        }
        if (collision.transform.gameObject.tag == "Boss")
        {
            if (collision.collider.GetType() == typeof(BoxCollider))
            {
                Debug.Log("Hit");
                collision.transform.gameObject.GetComponent<ShoeAIScript>().DealDmg();
            }
            else
            {
                // Receive dmg
            }
        }
    }
}
