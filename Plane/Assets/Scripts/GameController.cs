using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 position;
    [SerializeField] private float posMin = -0.3f;
    [SerializeField] private float posMax = 2.4f;
    private float points = 0f;
    [SerializeField] private Text pointsText;
    private int level = 1;
    [SerializeField] private Text levelText;
    [SerializeField] private float nextLevel = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Points();
        CreateObstacles();
        WinLevel();
    }

    //method for handling points
    private void Points()
    {
        points += Time.deltaTime;

        pointsText.text = Mathf.Round(points).ToString();
    }

    private void WinLevel()
    {
        levelText.text = level.ToString();
        
        if(points > nextLevel)
        {
            level++;
            nextLevel *= 2;
        }
    }

    //method to create obstacles
    private void CreateObstacles()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(1f, 3f);

            position.y = Random.Range(posMin, posMax);

            Instantiate(obstacle, position, Quaternion.identity);
        }
    }

    public int ReturnLevel()
    {
        return level;
    }
}
