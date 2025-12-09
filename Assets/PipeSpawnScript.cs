using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject Pipe;
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

        
        float lowerPoint = transform.position.y - heightOffset;     // y = -.13
        float highestPoint = transform.position.y + heightOffset;    // range we want: -5.49 ~ 4.77 so default heightoffset = 4.75!

        GameObject parent = Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 0), transform.rotation);

        if (spawned == 3)
        {
            spawned = 0;

            // Y values of pipes:
            float upperPipe = 11.3f;
            float lowerPipe = -10.7f;

            Transform topPipe = parent.transform.Find("Top Pipe");
            Transform bottomPipe = parent.transform.Find("Bottom Pipe");

            Debug.Log("Hello child_name = " + topPipe.name + " world Y position = " + topPipe.position.y);
            Debug.Log("Hello child_name = " + topPipe.name + " local Y position = " + topPipe.localPosition.y);

            topPipe.localPosition = new Vector3(0, upperPipe, 0);
            bottomPipe.localPosition = new Vector3(0, lowerPipe, 0);

        }
        spawned++;
    }
}
