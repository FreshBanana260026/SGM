using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

	void Start () {
        Destroy(gameObject, 15f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().HealNinja();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<Player>().HealNinja();
            Destroy(gameObject);
        }
            
    }
}
