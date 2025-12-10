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

    //private RButton button;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned == 3)
            spawnRate = 3f;
        else
        {
            spawnRate = 2;
        }

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

            GameObject top_btn = topPipe.transform.Find("red button").gameObject;
            top_btn.SetActive(true);

            





            // to look into types of positions and scales later: 

            //Debug.Log("Hello child_name = " + topPipe.name + " world Y position = " + topPipe.position.y);
            //Debug.Log("Hello child_name = " + topPipe.name + " local Y position = " + topPipe.localPosition.y);

            //Debug.Log("bottom pipe local scale: " + bottomPipe.localScale);
            //Debug.Log("bottom pipe lossy scale: " + bottomPipe.lossyScale);

        }
        else
        {
            float lowerPoint = transform.position.y - heightOffset;     // y = -.13
            float highestPoint = transform.position.y + heightOffset;    // range we want: -5.49 ~ 4.77 so default heightoffset = 4.75!

            GameObject parent = Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 0), transform.rotation);
            spawned++;
        }

        // to look into later: coroutines
        // google important conversation link: https://www.google.com/search?sourceid=chrome&udm=50&aep=26&mtid=5C84afOkKo-_juMP9vygwAY&ved=0CAkQ2_wOahcKEwjwp7iTmbKRAxUAAAAAHQAAAAAQDQ&atvm=1&mstk=AUtExfAhGLoA234N1_QHrhkKFotsYVKqTooQXWQCLzEFx4-z5nfI_N_NQ-rCXYgbBQEvqJcPPH1Dg9fX_ZYT1_UGfDL8DwargxjMDXqusbwL5qW5DjMkPrCMugMHZUgDjjNi1XIUdd0WmildLNm8xuWjUvn8tMdkDUlYa2ARpJvTjyxLcfVfLb-xhWFRSe9FOZn8zMstbiJEdZOLA_OLdvFrov9YPBCEBdyRKWERIcyzAuywbxyYXfcVHqfq9p9Giec858zF6uRUQPvRq7UNj_TNwSlkcD818VnaOpGcfA7p_ZSk0tMgKNs5syzWAMO1Q9Kf0bhLep6o1vjRKTGFP6buE1EDWKq2b0g3PTcMa8RhPFznNLAUVhHJzfeR2JBulqDqWQPD1jwDrNCrAJBr7leOqOSwJ7ghbhh0hA&csuir=1&q=use+of+rigidbody+in+unity
        // only in insaneshrey account, the link will work!
    }


}
