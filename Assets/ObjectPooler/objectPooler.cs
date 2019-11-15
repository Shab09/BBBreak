using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooler : MonoBehaviour {
    public GameObject poolObj;
    public List<GameObject> PoolList;
    // Use this for initialization
    void Awake () {
        PoolList = new List<GameObject> ();
        for (int i = 0; i < 4; i++) {
            GameObject obj = Instantiate (poolObj);
            obj.SetActive (false);
            PoolList.Add (obj);
        }
    }
    public void reNew(){
        PoolList = new List<GameObject> ();
        for (int i = 0; i < 4; i++) {
            GameObject obj = Instantiate (poolObj);
            obj.SetActive (false);
            PoolList.Add (obj);
        }
    }
    public GameObject getPooledObject () {

        for (int i = 0; i < PoolList.Count; i++) {
            if (PoolList[i]!=null && !PoolList[i].activeInHierarchy) {
                return PoolList[i];
            }
        }
        GameObject obj = Instantiate (poolObj);
        obj.SetActive (false);
        PoolList.Add (obj);
        return obj;
    }
}