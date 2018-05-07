using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpikes : MonoBehaviour {

    private float originalPosition;
    private bool toLeft;
    private Rigidbody2D rb;
    private float currentPosition;

    void Start () {
        originalPosition = transform.position.x;
        toLeft = true;
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        currentPosition = transform.position.x;
        if(currentPosition < -6.5)
        {
            toLeft = false;
        }
        if(currentPosition > originalPosition)
        {
            toLeft = true;
        }
	}

    private void FixedUpdate()
    {
        if(toLeft)
        {
            rb.velocity = Vector2.left;
        }
        if(!toLeft)
        {
            rb.velocity = Vector2.right;
        }
    }
}
