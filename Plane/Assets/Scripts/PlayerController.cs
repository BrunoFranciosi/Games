using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float velocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //taking my rb by yourself
        myRB = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //rising when pressing space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRB.velocity = Vector2.up * velocity;
        }

        if(myRB.velocity.y < -velocity)
        {
            myRB.velocity = Vector2.down * velocity;
        }
    }

    //player collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game");
    }
}
