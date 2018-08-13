using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayFinalScore : MonoBehaviour {

    [SerializeField] TMP_Text finalScore;
    float final;

    private void Start() {
        final = ScoreManager.GetFinalScore();
        finalScore.text = "Final Score: " + final;
    }
}
