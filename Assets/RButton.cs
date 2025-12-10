using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RButton : MonoBehaviour
{

    public Animator UpAnimator;

    

    private string triggerName = "MoveUpTrigger";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            //Debug.Log("collided with bullet bro!");

            UpAnimator = GetComponentInParent<Animator>();

            if(UpAnimator != null)
            {
                transform.parent.GetComponent<BoxCollider2D>().enabled = false;
                //Debug.Log("trigger fired!");
                UpAnimator.SetTrigger(triggerName);
            }
        }
        
    }
}
