using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainGame : MonoBehaviour
{
    
    public void loadMainGame(){
        Time.timeScale=1;
        GameValues.values.resetScore();
        GameValues.values.Turns=1;
        SceneManager.LoadScene("MainGame");
    }
}
