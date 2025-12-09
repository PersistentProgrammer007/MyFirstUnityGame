using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject Pipe;
    public GameObject ClosedPipe;
    public float heightOffset = 4.75f;
    public float spawnRate = 2;
    
    private float timer = 0;
    private int spawned = 0;



    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        // per 3 open pipes spawned, we need 1 close pipe with a button with which our bullet will collide and when it does, the pipes will move
        // to provide space enough for the bird to move through!

        //What I want: the bird shoots bullet (with sound) it travels ,when it collides with red button and its associated pipe goes to top with
        // animation!
        
        
      

        if (spawned == 3)
        {
            spawned = 0;

            // Y values of pipes:
            float lowerPoint = -5.1f;
            float higherPoint = 4f;

            GameObject parent = Instantiate(ClosedPipe, new Vector3(transform.position.x, Random.Range(lowerPoint, higherPoint) ,0), transform.rotation);

            Transform topPipe = parent.transform.Find("Top Pipe");       //randomly, this is the pipe with the red button:
            Transform bottomPipe = parent.transform.Find("Bottom Pipe"); // so this pipe has to have a scale effect, it could be also vice-versa

            Debug.Log("Hello child_name = " + topPipe.name + " world Y position = " + topPipe.position.y);
            Debug.Log("Hello child_name = " + topPipe.name + " local Y position = " + topPipe.localPosition.y);

            //topPipe.localPosition = new Vector3(0, upperPipe, 0);
            topPipe.transform.Find("red button").gameObject.SetActive(true);
            //topPipe.localScale = new Vector3()

            //bottomPipe.localPosition = new Vector3(0, lowerPipe, 0);
            //bottomPipe.localScale = new Vector3(1 , 0 , 1);

            //Debug.Log("bottom pipe local scale: " + bottomPipe.localScale);
            //Debug.Log("bottom pipe lossy scale: " + bottomPipe.lossyScale);

        } else
        {
            float lowerPoint = transform.position.y - heightOffset;     // y = -.13
            float highestPoint = transform.position.y + heightOffset;    // range we want: -5.49 ~ 4.77 so default heightoffset = 4.75!

            GameObject parent = Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 0), transform.rotation);
            spawned++;
        }
        
        
    }
}
