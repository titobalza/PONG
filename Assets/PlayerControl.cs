using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public float spd = 12f;
    [SerializeField] private bool isPaddle1;
    public float ybound = 0.2f;
    
    void Update()
    {
      float mov;

      if (isPaddle1)
      {
        mov = Input.GetAxisRaw("Vertical");
      }   
      else {
        mov = Input.GetAxisRaw("Vertical2");
      }

      Vector2 paddlepos=transform.position;

      paddlepos.y = Mathf.Clamp(paddlepos.y + mov *spd *Time.deltaTime, -ybound, ybound);
      transform.position = paddlepos;


    }
}
