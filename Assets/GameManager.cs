using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gamer1scoreText;
    [SerializeField] private TextMeshProUGUI gamer2scoreText;
    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    private int gamer1score;
    private int gamer2score;



    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void GolIzq()
{
    gamer1score++;
    gamer1scoreText.text = gamer1score.ToString();
    if (gamer1score >= 5)
    {
        gamer1scoreText.text = "Winner" ;
        RestartGame();
        
}
}
public void GolDer()
{
    gamer2score++;
    gamer2scoreText.text = gamer2score.ToString();
    if (gamer2score >= 5)
    {
       gamer2scoreText.text = "Winner";
       RestartGame();
       
       
    }
}
  public void Reinicio()
{
    paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
    paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);

    Ball[] balls = FindObjectsOfType<Ball>();
    foreach (Ball ball in balls)
    {
        ball.transform.position = new Vector2(0, 0);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        if (ballRb != null)
            ballRb.velocity = Vector2.zero;
    }
}
private void RestartGame()
{

    gamer1score = 0;
    gamer2score = 0;
    gamer1scoreText.text = "0";
    gamer2scoreText.text = "0";
}
}