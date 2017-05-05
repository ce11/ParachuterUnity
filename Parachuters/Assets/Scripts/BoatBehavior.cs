using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : SpaceAwareObject {
    public float boatSpeed = 2f;
    // Use this for initialization
    public override void Start () {
        base.Start();
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
}
