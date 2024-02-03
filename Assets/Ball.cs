using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 7f;
    [SerializeField] private float velocityMultiplier = 1.25f;

    private Rigidbody2D ballRb;    
    
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }


    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? -1 : 1;
        float yVelocity = Random.Range(0, 2) == 0 ? -1 : 1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }
    private float Multiplier()
    {
        float velocidad_actual = ballRb.velocity.magnitude;
        float p = Random.Range(0.5f, 1f);
        float d = Random.Range(1f, 3f);
        float v = Random.Range(0.5f, 3f);
        if (velocidad_actual < 8f)
        {
            return d;
        }
        else if (velocidad_actual > 16f)
        {
            return p;
        }
        else
        {
            return v;
        }
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Paddle"))
        {
            GameManager.Instance.UpdateSpeed();
            ballRb.velocity *= velocityMultiplier;         
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
            GameManager.Instance.UpdateSpeed();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal1"))
        {
            GameManager.Instance.GolDer();
            GameManager.Instance.Reinicio();
            Launch();
        }
        else if (collision.gameObject.CompareTag("Goal2"))
        {
            GameManager.Instance.GolIzq();
            GameManager.Instance.Reinicio();
            Launch();
        }
    }

}
