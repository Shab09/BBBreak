using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameValues : MonoBehaviour {

    public static GameValues values; //Globel refernce to values
    private float score = 1; //Score to e displayed
    [SerializeField]
    private float highscore = 0; //HighScore Value
    public float HighScore { get { return highscore; } set { highscore = value; } }

    [SerializeField]
    private float soundVolumn; //Sound setting
    public float SoundVolumn { get { return soundVolumn; } set { soundVolumn = value; } }

    [SerializeField]
    private float musicVolumn; //Music setting
    public float MusicVolumn { get { return musicVolumn; } set { musicVolumn = value; } }
    public int turns = 1; //Number of turns
    public int Turns { get { return turns; } set { turns = value; } } //Reference to number turns
    public bool inShoot = false; //If te player has shot the ball
    public bool InShoot { get { return inShoot; } set { inShoot = value; } } // Reference to the inShoot boolean

    //Struct To Save Highscore
    [Serializable]
    public struct hs {
        public float highscore;
        public float sound;
        public float music;
    }
    public hs hsObj;
    // Start is called before the first frame update
    void Awake () {
        //If there already exists a value item destroy it
        if (values == null) {
            DontDestroyOnLoad (gameObject);
            loadHighScore ();
            values = this;
        } else {
            Destroy (gameObject);
        }
    }
    private void Update () {

        //        Debug.Log((1.0f / Time.smoothDeltaTime));
    }
    public void setScore (float points) {
        score += points; // Increase scoreby number of points

    }
    public void resetScore () {
        score = 1;
    }
    public float getScore () {
        return score;
    }
    public void saveHightScore () {
        //if (score > highscore) {
        //highscore = score;

        //If the previous high score is greater then the new high score save new high score
        if (score >= highscore && highscore != hsObj.highscore) {
            score--;
            highscore = score;
        }
        hsObj.highscore = highscore;
        string JSON_highscore = JsonUtility.ToJson (hsObj);
        File.WriteAllText (Application.persistentDataPath + "/highscore.json", JSON_highscore);
    }

    public void loadHighScore () {
        //If file exists load values
        if (File.Exists ((Application.persistentDataPath + "/highscore.json"))) {
            Debug.Log (File.ReadAllText (Application.persistentDataPath + "/highscore.json"));
            hsObj = JsonUtility.FromJson<hs> (File.ReadAllText (Application.persistentDataPath + "/highscore.json"));
            highscore = hsObj.highscore;
            if (SoundChanger.soundChanger != null) {
                SoundChanger.soundChanger.musicSlider.value = hsObj.music;
                SoundChanger.soundChanger.soundSlider.value = hsObj.sound;
            }
        }
    }
    //Save volunm if changed
    public void saveSound () {
        hsObj.music = musicVolumn;
        hsObj.sound = soundVolumn;
        string JSON_highscore = JsonUtility.ToJson (hsObj);
        File.WriteAllText (Application.persistentDataPath + "/highscore.json", JSON_highscore);
    }
}