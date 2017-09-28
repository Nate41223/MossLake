using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().isInWater = true;
            collision.gameObject.GetComponent<PlayerPhysicsManagement>().waterPhysics();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().isInWater = false;
            collision.gameObject.GetComponent<PlayerPhysicsManagement>().normalPhysics();
        }
    }
}
