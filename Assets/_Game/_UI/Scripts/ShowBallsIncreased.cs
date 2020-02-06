using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ShowBallsIncreased : MonoBehaviour {
    public static ShowBallsIncreased ballsIncreasedTweener;//Self reference for globel access
    public CanvasGroup ShowBalls;//Canvas to display the number of balls increased
    public TextMeshProUGUI ballstext;//Ball increased text
    // Start is called before the first frame update
    void Start () {
        //Give self reference
        if (ballsIncreasedTweener == null) {
            ballsIncreasedTweener = this;
        }
        DOTween.Init ();//Initiate dotween
    }

    // Show Ball increased canvas
    public void ShowCanvas (int balls) {
        //Chnage background color with dotewwn
        GameObject.Find ("BG").GetComponent<SpriteRenderer> ().DOColor(Random.ColorHSV (),5f);
//        GameObject.Find ("BG").GetComponent<SpriteRenderer> ().color = Random.ColorHSV ();
        ballstext.text = "+" + balls + " Balls";//Change ball text
        ShowBalls.DOFade (1, 1f).OnComplete (() => { ShowBalls.DOFade (0, 1f); }); // Show and hide canvas
    }
}