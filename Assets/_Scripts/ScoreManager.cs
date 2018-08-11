using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour {

    static float highScore;
    static float currentScore;


	// Use this for initialization
	void Start () {
        currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void AddPoints(float pointsToGive) {
        currentScore += pointsToGive;
        DisplayScore();
    }

    static void  DisplayScore() {
        //TODO update "display" or wait till end of game?
        Debug.Log("Current Score: " + currentScore);
    }
}
