using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider c) {
        if (c.attachedRigidbody != null) {
            PowerUpCollector mc = c.attachedRigidbody.gameObject.GetComponent<PowerUpCollector>(); 

            if (mc != null) {
                mc.ReceiveDoubleJump();
                // EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
                if (c.transform.gameObject.tag == "Player") {  
                    Destroy(this.gameObject);
                }
            }
            
        }
    }
}
