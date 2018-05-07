using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))] // addes component to the object that the script is added to.
										// never get a null reference.
public class Knife : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Rigidbody2D myRigidbody;
	private Vector2 direction; // decides which direction we are throwing the knife 
	
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
        }
        
    }

	void FixedUpdate()
	{
		myRigidbody.velocity = direction * speed;
	}

    void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	public void Initialize(Vector2 direction)// public so we called it from the player
	{
		this.direction = direction;
	}
}
