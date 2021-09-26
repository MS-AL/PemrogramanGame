using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControllerYT : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void Update()
    {
        float arah = Input.GetAxis("Horizontal");
        if (arah < 0){
            rb.velocity = new Vector2 (-speed,0);
        }
        if (arah > 0){
            rb.velocity = new Vector2 (speed,0);
        }
        if (arah == 0){
            rb.velocity = new Vector2 (0,0);
        }
    }
}
