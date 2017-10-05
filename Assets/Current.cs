using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current : MonoBehaviour {

    private bool applySpeedBoost = false;

    Rigidbody2D player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (applySpeedBoost)
        {
            Vector3 localForward = -transform.right;
            Vector2 localForwards = new Vector2(localForward.x, localForward.y);

            player.velocity += localForwards * 100 * Time.deltaTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.GetComponent<PlayerMovement>().canJump = true;
            applySpeedBoost = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = null;
            collision.gameObject.GetComponent<PlayerMovement>().canJump = false;
            applySpeedBoost = false;
        }

    }
}
