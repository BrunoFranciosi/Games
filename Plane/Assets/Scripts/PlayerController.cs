using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float velocity = 5f;
    [SerializeField] private GameObject puff;

    // Start is called before the first frame update
    void Start()
    {
        //taking my rb by yourself
        myRB = GetComponent<Rigidbody2D>(); 

    }

    // Update is called once per frame
    void Update()
    {
        Up();

        if (myRB.velocity.y < -velocity)
        {
            myRB.velocity = Vector2.down * velocity;
        }

        restart();
    }

    private void Up()
    {
        //rising when pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRB.velocity = Vector2.up * velocity;

            //create the puff - putting the instance (gameobject) of the puff in the game's memory
            //saving the created instance in a variable
            GameObject myPuff = Instantiate(puff, transform.position, Quaternion.identity);
            //destroying my puff
            Destroy(myPuff, 2f);
        }
    }

    //restarting when exiting the screen
    private void restart()
    {
        if (transform.position.y > 5.5f || transform.position.y < -5.5f)
        {
            SceneManager.LoadScene("Game");
        }
    }

    //player collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game");
    }
}
