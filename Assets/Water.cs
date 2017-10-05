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

        if (collision.gameObject.tag == "Raft")
        {
            collision.gameObject.GetComponent<Raft>().waterPhysics();
            collision.gameObject.GetComponent<Raft>().isInWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().isInWater = false;
            collision.gameObject.GetComponent<PlayerPhysicsManagement>().normalPhysics();

            if (Input.GetButton("Jump"))
            {
                collision.gameObject.GetComponent<PlayerMovement>().waterJump();
            }
        }

        if (collision.gameObject.tag == "Raft")
        {
            collision.gameObject.GetComponent<Raft>().normalPhysics();
            collision.gameObject.GetComponent<Raft>().isInWater = false;
        }
    }
}
