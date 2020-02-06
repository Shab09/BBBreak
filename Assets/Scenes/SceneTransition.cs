using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transAnim;//Transition animator
    public string sceneName;//Scene to be loaded
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Function called to change the scene
    public void changeScene()
    {
        transAnim.SetTrigger("end");
        Time.timeScale=1;//Reset time scale
        GameValues.values.resetScore();//Reset values
        GameValues.values.Turns=1;//Reset turns

        Invoke("changeSceneInvoker",0.5f);//Invoke function to load scene

    }
    //Function that will load scene after wait
    void changeSceneInvoker(){
        SceneManager.LoadScene(sceneName);
    }
}
