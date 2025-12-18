using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class Birdscript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool isBirdAlive = true;
    public List<AudioClip> soundEffects;

    public GameObject bullet;
    public int bulletSpeed = 100;

    public PipeMiddleScript pms;

    //public Dictionary<string, AudioClip> sfxs; unity editor doesn't know how to serialize this, it only supports basic types and collections.

    private PlayerInput playerinput;

    private InputAction jump;
    private InputAction fire;

    private AudioSource myAudioSource;
    private int totalSfx = 6;
    

    // Start is called before the first frame update
    // but what about awake() ?
    void Awake()
    {

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myAudioSource = GetComponent<AudioSource>();

        myAudioSource.volume = 0.5f;
        pms.Pipe += changeNPlaySound;

        playerinput = GetComponent<PlayerInput>();
        jump = playerinput.actions["jump"];
        fire = playerinput.actions["fire"];

        //Debug.Log("clip " + myAudioSource.clip);

        //Debug.Log("Current Scene Index: " + SceneManager.GetActiveScene().buildIndex);
        
    }

    void Update()
    {

        if ( myRigidBody.position.x <= -16 || myRigidBody.position.y <= -10 )
        {
            if(isBirdAlive)
                changeNPlaySound("game_over");

            logic.gameOver();
            isBirdAlive = false;
        }
       
    }

    private void OnEnable()
    {
        jump.performed += Jumping;
        fire.performed += Shooting;

    }

 

    private void Jumping(InputAction.CallbackContext obj)
    {

        if (isBirdAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            changeNPlaySound("jump");
        }

    }

    private void Shooting(InputAction.CallbackContext obj)
    {
        if (isBirdAlive)
        {
            changeNPlaySound("gunshot");


            GameObject SpawnedBullet = Instantiate(bullet, new Vector3(0 + 1, transform.position.y ,0), transform.rotation);

            SpawnedBullet.GetComponent<SpawnBullet>().ButtonHit = soundEffects[4];
            SpawnedBullet.GetComponent<SpawnBullet>().PipeHit = soundEffects[5];

            Rigidbody2D rb = SpawnedBullet.GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * bulletSpeed;  
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("hello this is in birdscript");

        if (isBirdAlive)
        {
            changeNPlaySound("game_over");
            logic.gameOver();
        }

        isBirdAlive = false;
    }

    private bool changeNPlaySound(string sfx_name)
    {
        if (soundEffects.Count != totalSfx)
        {
            Debug.Log("Not all sound files are present!");
            return false;
        }

        if (sfx_name == "coin")
            myAudioSource.clip = soundEffects[0];

        else if (sfx_name == "game_over")
            myAudioSource.clip = soundEffects[1];

        else if (sfx_name == "jump")
            myAudioSource.clip = soundEffects[2];

        else if (sfx_name == "gunshot")
            myAudioSource.clip = soundEffects[3];

        //Debug.Log(sfx_name); 

        myAudioSource.volume = 0.6f;
        myAudioSource.Play();

        return true;
    }

    private void OnDisable()
    {
        jump.performed -= Jumping;
        fire.performed -= Shooting;
    }

    /*
     
    Features to be added: 
    look into the new input system                                                                         Have not looked into it
    TextMeshPro                                                                                            Looked into it and used it

    game over when the bird is off-the-screen,                                                             done
    add audio / sound effects in the game,                                                                 done
    particle system to add moving clouds in the game,
    animation window to add flapping wings,                                                                done 
    another screen for title-screen (clue: i will have to add the scene to the build settings window!),    done
    PlayerPrefs to save a player's high score,                                                             done
    
    expand on flappy bird, adding some unique elements that weren't there in the original flappy bird!

    Next: take other games and remake them like pong, offline dino game, 
     
     */

}
