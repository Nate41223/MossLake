using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsManagement : MonoBehaviour {

    private float normalMass;
    private float normalLinearDrag;
    private float normalAngularDrag;
    private float normalGravityScale;

    private float waterMass = 1;
    private float waterLinearDrag = 8;
    private float waterAngularDrag = .05f;
    private float waterGravityScale = 0;

    // Use this for initialization
    void Start () {
        normalMass = GetComponent<Rigidbody2D>().mass;
        normalLinearDrag = GetComponent<Rigidbody2D>().drag;
        normalAngularDrag = GetComponent<Rigidbody2D>().angularDrag;
        normalGravityScale = GetComponent<Rigidbody2D>().gravityScale;
    }

    public void waterPhysics()
    {
        GetComponent<Rigidbody2D>().mass = waterMass;
        GetComponent<Rigidbody2D>().drag = waterLinearDrag;
        GetComponent<Rigidbody2D>().angularDrag = waterAngularDrag;
        GetComponent<Rigidbody2D>().gravityScale = waterGravityScale;
    }

    public void normalPhysics()
    {
        GetComponent<Rigidbody2D>().mass = normalMass;
        GetComponent<Rigidbody2D>().drag = normalLinearDrag;
        GetComponent<Rigidbody2D>().angularDrag = normalAngularDrag;
        GetComponent<Rigidbody2D>().gravityScale = normalGravityScale;
    }
}
