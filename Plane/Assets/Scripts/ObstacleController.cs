using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private GameObject montanha;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(montanha, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //going left
        transform.position += Vector3.left * Time.deltaTime * velocity;
    }
}
