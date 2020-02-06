using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHolder : MonoBehaviour
{
    public static SoundHolder soundHolder;
    public AudioSource backgroundAudio;
    private void Awake() {
        soundHolder=this;
    }
    private void Update() {
        backgroundAudio.volume=GameValues.values.MusicVolumn;
    }
}
