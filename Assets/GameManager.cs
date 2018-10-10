using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<Ball> balls = new List<Ball>();

    float ballSpawnerTimer = 0f;
    float timeToSpawn = 5f;
    public float ballForce = 1f;
    public UnityEngine.UI.Text text;

    private void Awake()
    {

        text.text = ballForce.ToString();
    }

    private void Start()
    {
        Reset();
    }

    public void AddBallForce()
    {
        ballForce += 50;
        text.text = ballForce.ToString();
    }

    public void SubtractBallForce()
    {
        ballForce -= 50f;
        text.text = ballForce.ToString();

    }

    public void Reset()
    {
        foreach(var ball in balls)
        {
            ball.ResetBall();
        }
        balls[0].gameObject.SetActive(true);
        balls[0].Spawn();
        balls[1].gameObject.SetActive(false);
        balls[2].gameObject.SetActive(false);
        ballSpawnerTimer = 0f;
    }

    private void Update()
    {
        ballSpawnerTimer += Time.deltaTime;
        if(ballSpawnerTimer >= timeToSpawn * 2 && balls[2].haveSpawned == false)
        {
            balls[2].gameObject.SetActive(true);
            balls[2].Spawn();
        }
        else if(ballSpawnerTimer >= timeToSpawn && balls[1].haveSpawned == false)
        {
            balls[1].gameObject.SetActive(true);
            balls[1].Spawn();
        }
    }

}
