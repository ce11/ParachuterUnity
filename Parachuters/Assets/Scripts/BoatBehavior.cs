using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour {
    public float boatSpeed = 2f;
    private float leftBorder, rightBorder;
    // Use this for initialization
    void Start () {
        // Init borders
        var dist = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightBorder)
        {
            var pos = transform.position;
            pos.x += boatSpeed * Time.deltaTime;
            transform.position = pos;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftBorder)
        {
            var pos = transform.position;
            pos.x += boatSpeed * -1 * Time.deltaTime;
            transform.position = pos;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Boat Collide");
    }

}
