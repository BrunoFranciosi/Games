using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    private Vector3 myPosition;
    private float myY;
    public float velocity = 5f;
    public float myLimit = 3.5f;
    //Cariable to control the AI
    public bool AI = false;
    //Identifying who is player 1
    public bool player1;
    //Getting the ball position
    public Transform transformBall;

    // Start is called before the first frame update
    void Start()
    {
        //Taking the initial position of the racket and applying it to my position
        myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myPosition.y = myY;

        //Modify the position of my racket
        transform.position = myPosition;

        float deltaVelocity = velocity * Time.deltaTime;

        if (!AI)
        {
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
            }
            else
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    AI = true;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    myY = myY + deltaVelocity;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    myY = myY - deltaVelocity;
                }
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
                AI = false;
            }

            myY = transformBall.position.y;
            Mathf.Lerp(myY, transformBall.position.y, 0.02f);
        }

        //Preventing me from going over the screen
        if (myY > myLimit)
        {
            myY = myLimit;
        }

        //Preventing me from getting out from under the screen
        if (myY < -myLimit)
        {
            myY = -myLimit;
        }
    }
}
