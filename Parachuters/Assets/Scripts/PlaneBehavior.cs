using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehavior : MonoBehaviour
{
    public float planeSpeed = -2f;
    private float leftBorder, rightBorder;
    // Use this for initialization
    void Start()
    {
        // Init borders
        var dist = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        // Start movement
        StartMovement();
    }

    void FixedUpdate()
    {
        if (transform.position.x < leftBorder)
        {
            var pos = transform.position;
            pos.x = rightBorder;
            transform.position = pos;
        }
    }

    void StartMovement()
    {
        // Setting plane velocity
        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
        newVelocity.x = planeSpeed;
        GetComponent<Rigidbody2D>().velocity = newVelocity;

        // Setting plane orientation
        transform.localScale = new Vector3(planeSpeed < 0 ? 1f : -1f, 1f, 1f);
    }

}
