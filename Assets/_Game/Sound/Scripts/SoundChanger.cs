using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChanger : MonoBehaviour {
    public static SoundChanger soundChanger;
    public Slider musicSlider; // Slider to control sound of music
    public Slider soundSlider; // Slider to control sound

    private void Awake () {
        soundChanger = this;
    }
    // Update is called once per frame
    void Update () {
        if (musicSlider.value != GameValues.values.MusicVolumn) {
            GameValues.values.MusicVolumn = musicSlider.value; // Assign value for globel access
            GameValues.values.saveSound ();
        }
        if (soundSlider.value != GameValues.values.SoundVolumn) {
            GameValues.values.SoundVolumn = soundSlider.value; // Assign value for globel access
            GameValues.values.saveSound ();
        }
    }
}