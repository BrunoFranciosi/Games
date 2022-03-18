using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D myRB;
    private Vector2 myVelocity;
    public float Velocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //passing the velocity to myVelocity
        myVelocity.x = -Velocity;

        //adding speed to the left
        myRB.velocity = myVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
