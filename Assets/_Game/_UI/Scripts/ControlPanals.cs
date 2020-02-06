using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ControlPanals : MonoBehaviour {

    public GameObject panal; //The panal value that needs to be controled
    private bool open;

    void Start () {
        DOTween.Init (); //Initialize dotween
    }

    //Control panal state
    public void controlPanal () {
        if (open) {
            closePanal ();
        } else {
            openPanal ();
        }
    }

    //Open panal
    public void openPanal () {
        panal.transform.DOScale (new Vector3 (1, 1, 1), 1);
        open = true; //Set panal value to open
    }

    //Close panal
    public void closePanal () {
        panal.transform.DOScale (new Vector3 (0, 0, 0), 1);
        open = false; //Set panal value to close
    }
}