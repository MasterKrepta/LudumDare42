using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour {

    static float highScore;
    static float currentScore;
    static TMP_Text txtScore;

    // Use this for initialization
    void Start () {
        currentScore = 0;
        txtScore = GameObject.Find("Score").GetComponent<TMP_Text>(); //THIS IS DANGEROUS
        txtScore.text = "Score: " + currentScore;
    }

    public static void AddPoints(float pointsToGive) {
        currentScore += pointsToGive;
        DisplayScore();
    }

    static void  DisplayScore() {
        //Should I wait till end of game? And do I want a high score based on player prefs (Probobly not important for a jam game)
        txtScore.text = "Score: " + currentScore;
    }
}
