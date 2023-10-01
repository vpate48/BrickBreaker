using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 150;
    public UiManager Ui;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (Ui.gameOver)
        {
            return;
        }
        float h =Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("extraLife"))
        {
            Ui.UpdateLives(1);
            Destroy(col.gameObject);
        }
    }

    
}
