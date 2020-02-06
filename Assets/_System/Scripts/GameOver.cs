using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Canvas GameOverCanvas; // Canvass Reference to Gameover screen
    public CanvasGroup GameOverMenuCanvas;//Canvas group refernce of game oveer screen
    public RectTransform text;//Text rect transform
    public ShootBall player; //Shoot Ball Reference of player
    private bool GameOverStarted;//Check if game over process has began
    public LoadAds gameAds; // Google Ad holder object
    private void Awake()
    {
        DOTween.Init();//Initiate dotween
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check if any block has reached gameover point
        if (other.tag == "Block" || other.tag == "BossBlock" && !GameOverStarted)
        {
            GameValues.values.saveHightScore();//Call function to Save highscore
            GameOverStarted = true;//Set gameover started to true
            GameOverCanvas.enabled = true;//Enable gameover screen
            GameOverMenuCanvas.DOFade(1, 1.5f).OnComplete(() => Time.timeScale = 0);//Fade into screen in seconds
            text.DOScale(1, 1f);//Scale text to appear
            player.enabled = false;
            gameAds.gameover();

            //StartCoroutine(openGameOverMenu());
        }
    }

    // IEnumerator openGameOverMenu(){

    //     while(GameOverMenuCanvas.alpha<1f){
    //         yield return new WaitForSeconds(Time.deltaTime);
    //         GameOverMenuCanvas.alpha +=Time.deltaTime*5f;
    //     }
    //     Time.timeScale=0;
    //     yield return 0;
    // }
}