using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{

    //public GameObject bird; // instead of creating a bird gameobject or birdscript object, we should use birdscript itself to load properties: 

    public AudioClip ButtonHit { private get; set; }
    public AudioClip PipeHit { private get; set; }

    private AudioSource ads;

    private BoxCollider2D bCollider;
    private SpriteRenderer sr;

    private bool hasCollided = false;
    private void Start()
    {

        ads = GetComponent<AudioSource>();

        bCollider = gameObject.GetComponent<BoxCollider2D>();

        sr = gameObject.GetComponent<SpriteRenderer>();

        // bird = new Birdscript();
        // this gives error: You are trying to create a MonoBehaviour using the 'new' keyword.  This is not allowed.
        // MonoBehaviours can only be added using AddComponent(). Alternatively, your script can inherit from ScriptableObject or no base class at all
        // UnityEngine.MonoBehaviour:.ctor()


    }

    private void Update()
    {
        if (transform.position.x > 15)
        {
            Debug.Log("destroyed the bullet");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hasCollided)
        {
            return;
        }

        Debug.Log("name of this object: " + gameObject.name);
        Debug.Log("name of collided object: " + collision.gameObject.name);

        if (collision.gameObject.name == "Top Pipe" || collision.gameObject.name == "Bottom Pipe")
        {
            //play a error sound: 
            //ads.clip = bird.soundEffects[5];
            //Debug.Log("audioclip of pipe when hit = " + PipeHit);

            ads.clip = PipeHit;

        }
        else if (collision.gameObject.name == "red button")
        {
            // play a button hit sound: 
            //ads.clip = bird.soundEffects[4];
            //Debug.Log("audioclip of button when hit = " + ButtonHit.name);

            ads.clip = ButtonHit;
        }
        // Solved the Bug: when 1 bullet was close enough to another bullet, it caused NullReferenceException as ads.clip would be null;
        // This condition solves it!
        else if (collision.gameObject.name == gameObject.name) 
        {
            ads.clip = null;
        }

        hasCollided = true;

        if (ads.clip != null)
        {
            Debug.Log("not null");
            ads.volume = 0.8f;
            ads.Play();

            StartCoroutine(WaitTillSoundFinishes(ads.clip.length, ads.clip.name));
        } else
        {
            StartCoroutine(WaitTillSoundFinishes(0.2f, gameObject.name));
        }
        // wait for the sound to end, so we can destroy the object:
        
    }

    //IEnumerator WaitTillSoundEnds()  
    //{
    //    yield return new WaitForSeconds(ads.clip.length);
        
    //    Destroy(gameObject);
    //}

    IEnumerator WaitTillSoundFinishes(float soundLength, string soundName)
    {
        if(soundName == ButtonHit.name)
        {

            yield return new WaitForSeconds(0.25f);

            bCollider.enabled = false;
            sr.enabled = false;
        } else
        {
            yield return new WaitForSeconds(soundLength);
        }

        Destroy(gameObject);
    }

    
}
