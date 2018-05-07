using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1Score : MonoBehaviour {

    public static int scoreValue1 = 0;
    Text Player1Score;

	// Use this for initialization
	void Start () {
        Player1Score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Player1Score.text = "" + scoreValue1;
	}
    //needs to update when  ninja or robot die add 1 point ( player1Score.scoreValue1+=1; )
}
