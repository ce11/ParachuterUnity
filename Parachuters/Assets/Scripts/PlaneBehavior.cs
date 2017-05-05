using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehavior : SpaceAwareObject
{
    public float planeSpeedIncrement = 1.2f;
    public float planeSpeed = -2f;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
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

    public void IncrementPlaneSpeed()
    {
        planeSpeed *= planeSpeedIncrement;
    }
}
