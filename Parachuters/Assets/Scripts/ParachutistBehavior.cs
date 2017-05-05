using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachutistBehavior : MonoBehaviour
{
    public System.Action caughtParachuter;
    public System.Action missedParachuter;
    private float bottomBorder;
    MainScript main;
    // Use this for initialization
    void Start()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        Debug.Log("New Parachute " + bottomBorder);
        main = GameObject.Find("Main Camera").gameObject.GetComponent<MainScript>();
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
        Debug.Log("Parachute Trigger");
        if (caughtParachuter != null)
        {
            caughtParachuter.Invoke();
        }
        Destroy(gameObject);
    }
}
