using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public Transform powerup;
    public UiManager ui;
    public Transform explosion;
    public int points=1;
    
    void Start()
    {
        ui = GameObject.FindWithTag("ui").GetComponent<UiManager>();
    }



    void OnCollisionEnter2D( Collision2D collisionInfo)
    {
        int rand = Random.Range(1, 101);
        if(rand < 50)
        {
            Instantiate(powerup, gameObject.transform.position, gameObject.transform.rotation);
        }
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        ui.IncreaseScore(points);
        ui.UpdateBrickNum();
        Destroy(gameObject);
    }
    
}
