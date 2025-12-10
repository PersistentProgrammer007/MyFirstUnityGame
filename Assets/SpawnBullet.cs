using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Top Pipe" || collision.gameObject.name == "Bottom Pipe")
        {
            // play a error sound: 
            
        } else if (collision.gameObject.name == "red button")
        {
            // play a button hit sound: 
        }
        // wait for the sound to end then destory:
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.x > 15)
        {
            Debug.Log("destroyed the bullet");
            Destroy(gameObject);
        }
    }
}
