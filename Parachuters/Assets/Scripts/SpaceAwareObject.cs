using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceAwareObject : MonoBehaviour {
    protected float leftBorder, rightBorder, bottomBorder;
    protected Vector3 objectSize;
    // Use this for initialization
    public virtual void Start () {
        var dist = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var collider = GetComponent<Collider2D>();
        if(collider != null)
        {
            objectSize = collider.bounds.size;
        }
    }
}
