using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float velocity = 4f;
    [SerializeField] private GameObject montanha;
    [SerializeField] private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(montanha, 5f);

        //finding the game controller of the current scene
        game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //going left
        transform.position += Vector3.left * Time.deltaTime * velocity;

        velocity = 4f + game.ReturnLevel();
    }
}
