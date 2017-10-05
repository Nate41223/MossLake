using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour {

    private float normalGravityScale;
    private float waterGravityScale = 0;

    private bool isGrounded = false;
    public bool isAttached = false;
    public bool isInWater = false;

    public Rigidbody2D player;

    // Use this for initialization
    void Start () {
        normalGravityScale = GetComponent<Rigidbody2D>().gravityScale;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetKeyDown(KeyCode.E) && isGrounded == true && isAttached == false)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            isAttached = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isGrounded == true && isAttached == true)
        {
            isAttached = false;
        }

        if (isGrounded == false)
        {
            isAttached = false;
        }

        if (isAttached)
        {
            GetComponent<Rigidbody2D>().velocity = player.velocity;
        }
	}

    public void waterPhysics()
    {
        GetComponent<Rigidbody2D>().gravityScale = waterGravityScale;
        //GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y - GetComponent<Rigidbody2D>().velocity.y * Time.deltaTime - .f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void normalPhysics()
    {
        GetComponent<Rigidbody2D>().gravityScale = normalGravityScale;

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().canJump = true;
            isGrounded = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().canJump = false;
            isGrounded = false;
        }

    }
}
