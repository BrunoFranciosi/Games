using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float velocity = 5f;
    [SerializeField] private GameObject myShot;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 myvelocity = new Vector2(horizontal, vertical);
        myvelocity.Normalize();

        myRB.velocity = myvelocity * velocity;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(myShot, transform.position, transform.rotation);
        }
    }
}
