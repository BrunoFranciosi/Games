using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    private Vector3 myPosition;
    private float myY;
    public float velocity = 5f;
    public float myLimit = 3.5f;

    //identifying who is player 1
    public bool player1;

    // Start is called before the first frame update
    void Start()
    {
        //taking the initial position of the racket and applying it to my position
        myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myPosition.y = myY;

        //Modify the position of my racket
        transform.position = myPosition;

        float deltaVelocity = velocity * Time.deltaTime;

        if (player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myY = myY + deltaVelocity;
            }

            if (Input.GetKey(KeyCode.S))
            {
                myY = myY - deltaVelocity;
            }
        }else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                myY = myY + deltaVelocity;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                myY = myY - deltaVelocity;
            }
        }

        //preventing me from going over the screen
        if (myY > myLimit)
        {
            myY = myLimit;
        }

        //preventing me from getting out from under the screen
        if (myY < -myLimit)
        {
            myY = -myLimit;
        }
    }
}
