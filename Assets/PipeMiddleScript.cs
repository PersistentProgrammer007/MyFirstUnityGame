using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logic;
    //public Text highScore;
    
    // for indirectly using soundeffects list in birdscript.cs file but it doesn't work!
    public delegate bool PassedThePipe(string coin_sfx);
    public PassedThePipe Pipe;



    private AudioSource ads;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        ads = GetComponent<AudioSource>();
        

        ads.volume = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entered the trigger!");

        GameObject overScreen = GameObject.FindWithTag("game_over_screen");

        // null would mean that the gameoverscreen object isn't active
        if (overScreen == null)
        {
            if (collision.gameObject.layer == 3)
            {
                //Pipe?.Invoke("coin");
                ads.Play();
                logic.addScore(1);
            }
        } 

    }

}
