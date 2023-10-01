using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 55;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f)* Time.deltaTime * speed); // this makes the power up travel downwards 
        if(transform.position.y < -145f)
        // when the power up has passed the racket and is no longer seen on in the game we destory it
        {
            Debug.Log("power destoryed");
            Destroy(gameObject);
        }
    }
}
