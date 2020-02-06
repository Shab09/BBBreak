using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour {
    public CanvasGroup ToastMessage; //Message to display
    public Canvas ExitCanvas; // Canvass Reference to Gameover screen
    public CanvasGroup ExitMenuCanvas; //Canvas group refernce of game oveer screen
    private bool messageDisplaying; //Check if message is displaying
    private bool exitActive;
    // Start is called before the first frame update
    private void Awake () {
        DOTween.Init (); //Initiate dotween
    }

    // Update is called once per frame
    void Update () {
        //Check if exit button is pressed
        if (Input.GetKeyDown (KeyCode.Escape) && SceneManager.GetActiveScene ().name == "MainGame" && !exitActive && Time.timeScale>0) {
            activateExit();
        }else if(Input.GetKeyDown (KeyCode.Escape)&& SceneManager.GetActiveScene ().name != "MainGame") {
            //Check if mesage is already displaying
            if (messageDisplaying) {
                exitApp (); //Call exit app button
                return;
            }
            ToastMessage.DOFade (1, 1f).OnComplete (FadeOut); //Fade in toast message
            messageDisplaying = true; //Turn message displaying to true
        }
    }
    public void activateExit () {
        exitActive=true;//Exit mode is active
        ExitCanvas.enabled = true; //Enable gameover screen
        ExitMenuCanvas.DOFade (1, 1.5f).OnComplete(()=>Time.timeScale=0); //Fade into screen in seconds
    }
    public void deactivateExit(){
        Time.timeScale=1;
        ExitMenuCanvas.DOFade (0, 1.5f).OnComplete(()=>{ExitCanvas.enabled = false;}); //Fade out of screen in seconds
        
        exitActive=false;//Exit mode is not active
        //ExitCanvas.enabled = false; //Disable gameover screen
    }
    //Function to fade out message
    void FadeOut () {
        ToastMessage.DOFade (0, 3f).OnComplete (TurnOffDisplay); //Fade out toast message
    }
    void TurnOffDisplay () {
        messageDisplaying = false; //Set message displaying to false
    }
    public void exitApp () {
        Application.Quit (); //Quit application
    }
}