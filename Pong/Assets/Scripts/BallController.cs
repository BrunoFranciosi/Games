using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public Rigidbody2D myRB;
    private Vector2 myVelocity;
    public float Velocity = 5f;
    public float horizontalLimit = 12f;
    public AudioClip sound;
    public Transform transformCam;
    public float delay = 2f;
    public bool startingGame = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay - Time.deltaTime;

        if(delay <= 0 && startingGame == false)
        {
            startingGame = true;

            //Passing the velocity to myVelocity
            myVelocity.x = -Velocity;

            //Generating random value for the ball
            int direction = Random.Range(0, 4);

            if (direction == 0)
            {
                myVelocity.x = Velocity;
                myVelocity.y = Velocity;
            }
            else if (direction == 1)
            {
                myVelocity.x = -Velocity;
                myVelocity.y = Velocity;
            }
            else if (direction == 2)
            {
                myVelocity.x = -Velocity;
                myVelocity.y = -Velocity;
            }
            else
            {
                myVelocity.x = Velocity;
                myVelocity.y = -Velocity;
            }

            //Adding speed to the left
            myRB.velocity = myVelocity;
        }

        //Checking if the ball left the screen
        if (transform.position.x > horizontalLimit || transform.position.x < -horizontalLimit)
        {
            //Reloading my scene
            SceneManager.LoadScene("Game");
        }
    }

    //Creating collision event
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(sound, transformCam.position);
    }
}
