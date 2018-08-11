using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour {

    float highScore;
    float currentScore;


	// Use this for initialization
	void Start () {
        currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPoints(float pointsToGive) {
        currentScore += pointsToGive;
        DisplayScore();
    }

    void DisplayScore() {
        //TODO update "display" or wait till end of game?
    }
}
