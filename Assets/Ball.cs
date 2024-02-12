using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 7f;
    [SerializeField] private float velocityMultiplier = 1.20f;
    [SerializeField] private int hitCountToDuplicate = 7;
    private int currentHitCount = 0;

    private Rigidbody2D ballRb;
    private Camera mainCamera;
    private AudioSource audioSource;

    public float initialPitch = 1f;

    private void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();

        Launch();
    }

    private void Launch()
    {
        if (ballRb != null)
        {
            float xVelocity = Random.Range(0, 2) == 0 ? -1 : 1;
            float yVelocity = Random.Range(0, 2) == 0 ? -1 : 1;
            ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;

            if (audioSource != null)
            {
                audioSource.pitch = initialPitch;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= velocityMultiplier;

            if (audioSource != null)
            {
                audioSource.pitch *= velocityMultiplier;
            }

            currentHitCount++;

            if (currentHitCount >= hitCountToDuplicate)
            {
                currentHitCount = 0;
                DuplicateBall();
                ChangeBackgroundColor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            GameManager.Instance.GolDer();
            GameManager.Instance.Reinicio();
            DestroyDuplicateBalls();
            Launch();
        }
        else if (collision.gameObject.CompareTag("Goal2"))
        {
            GameManager.Instance.GolIzq();
            GameManager.Instance.Reinicio();
            DestroyDuplicateBalls();
            Launch();
        }
    }

    private void DuplicateBall()
    {
        GameObject newBall = Instantiate(gameObject, transform.position, Quaternion.identity);
        Ball newBallComponent = newBall.GetComponent<Ball>();

        if (newBallComponent != null)
        {
            newBallComponent.ballRb = newBall.GetComponent<Rigidbody2D>();
            newBallComponent.mainCamera = mainCamera;
            newBallComponent.Launch();
        }
    }

    private void ChangeBackgroundColor()
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;
        Color randomColor = new Color(r, g, b);
        mainCamera.backgroundColor = randomColor;
    }

    private void DestroyDuplicateBalls()
    {
        Ball[] duplicateBalls = FindObjectsOfType<Ball>();
        foreach (Ball duplicateBall in duplicateBalls)
        {
            if (duplicateBall != this)
            {
                Destroy(duplicateBall.gameObject);
            }
        }
    }
}