using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int walkSpeed = 60;
    public int runSpeed = 100;
    public bool canJump = false;

    Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isRunning()) LeftRightMovement(runSpeed);
        else LeftRightMovement(walkSpeed);

        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            body.AddForce(new Vector2(0, 30), ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private bool isRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift)) return true;
        return false;
    }

    private void LeftRightMovement(int speed)
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            body.velocity += new Vector2(speed * Input.GetAxis("Horizontal"), 0) * Time.deltaTime;
            if (transform.rotation.y == -1) transform.Rotate(new Vector3(0, -180, 0));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            body.velocity += new Vector2(speed * Input.GetAxis("Horizontal"), 0) * Time.deltaTime;
            if (transform.rotation.y == 0) transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
