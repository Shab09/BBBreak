using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplayHandler : MonoBehaviour {
    public TextMeshProUGUI scoreBoard; //Refernce to score displayed
    public TextMeshProUGUI highScoreBoard; //Refernce to highscore display
    private GameValues values;
    // Start is called before the first frame update
    void Start () {
        values = GameValues.values; // Get game values
    }

    // Update is called once per frame
    void Update () {
        //Check if there is scoreboard
        if (scoreBoard != null) {
            scoreBoard.text = values.getScore ().ToString ();//Display current score on scoreboard
        }

        //Check if the high score is greater then current score
        if (values.HighScore >= values.getScore ())
            highScoreBoard.text = "Top: " + values.HighScore;//Display highscore
        else
            values.HighScore = values.getScore ();//Change highscore value
    }
}