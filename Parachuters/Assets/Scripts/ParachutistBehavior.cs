using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutistBehavior : SpaceAwareObject
{
    public float baseGravity = 0.3f;
    public System.Action caughtParachuter;
    public System.Action missedParachuter;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        GetComponent<Renderer>().enabled = true;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (transform.position.y - transform.localScale.y < bottomBorder)
        {
            if(missedParachuter != null)
            {
                missedParachuter.Invoke();
            }
            
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore collisions with objects that are not boats
        if(other.gameObject.name != "boat")
        {
            return;
        }

        if (caughtParachuter != null)
        {
            caughtParachuter.Invoke();
        }
        Destroy(gameObject);
    }
}
