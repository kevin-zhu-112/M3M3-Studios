using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject attack;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.CompareTag("Player"))
        {
            var look = c.collider.gameObject.transform.position - transform.position;
            look.y = 0;
            Instantiate(attack, transform.position, Quaternion.LookRotation(look));
            Destroy(gameObject);
        }
    }
}
