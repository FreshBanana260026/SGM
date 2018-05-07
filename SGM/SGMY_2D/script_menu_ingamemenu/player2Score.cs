using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2Score : MonoBehaviour
{

    public static int scoreValue2 = 0;
    Text Player2Score;

    void Start()
    {
        Player2Score = GetComponent<Text>();
    }

 
    void Update()
    {
        Player2Score.text = "" + scoreValue2;
    }
    //needs to update when  ninja or robot die add 1 point ( player1Score.scoreValue1+=1; )
}	

