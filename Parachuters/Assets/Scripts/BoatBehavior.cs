using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : SpaceAwareObject {
    public float boatSpeed = 2f;
    private readonly int right = 1;
    private readonly int left = -1;
    // Use this for initialization
    public override void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            Move(Camera.main.ScreenToWorldPoint(touch.position).x > transform.position.x ? right : left);
        }
#else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(right);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(left);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x ? right : left);
        }
#endif
    }
    private void Move(int direction)
    {
        var pos = transform.position;
        if(pos.x + objectSize.x/2 <= rightBorder && direction == right || pos.x - objectSize.x / 2 >= leftBorder && direction == left) 
        {
            pos.x += boatSpeed * direction * Time.deltaTime;
            transform.position = pos;
            transform.localScale = new Vector3(1f * -direction, 1f, 1f);
        }

    }
}
