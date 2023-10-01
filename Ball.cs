using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 100.0f;
    public UiManager Ui;
    public bool inPlay;
    public Transform paddle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Ui.gameOver)
        {
            return;
        }

        if (!inPlay) // inPlay ==false
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("bottom"))
        {
            Debug.Log("ball hit bottom");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            inPlay = false;
            Ui.UpdateLives(-1);
        }
    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}
