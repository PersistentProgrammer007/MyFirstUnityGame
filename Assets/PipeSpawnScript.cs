using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject Pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 4.75f;

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
        float lowerPoint = transform.position.y - heightOffset;     // y = -.13
        float highestPoint = transform.position.y + heightOffset;    // range we want: -5.49 ~ 4.77 so default heightoffset = 4.75!


        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 0), transform.rotation);
    }
}
