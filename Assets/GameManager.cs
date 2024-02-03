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
    [SerializeField] private TextMeshProUGUI ballSpeed;


    private int gamer1score;
    private int gamer2score;
    private int h = 0;



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
    }
    public void GolDer()
    {
        gamer2score++;
        gamer2scoreText.text = gamer2score.ToString();
    }

    public void UpdateSpeed()
    {
        h++;
        ballSpeed.text = h.ToString();
    }

    public void Reinicio()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }
}