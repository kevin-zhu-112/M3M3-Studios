using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleObstacleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale > .001f)
        {
            transform.position += new Vector3(0, 0, 0.2f);
        }
        if (transform.position.z >= 45)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 400 + transform.up * 400);
            Destroy(gameObject);
        }
    }

}
