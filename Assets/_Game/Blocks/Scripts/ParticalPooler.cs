using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalPooler : MonoBehaviour
{
    public static ParticalPooler particalPooler;
    public objectPooler particals;
    // Start is called before the first frame update
    void Start()
    {
        particalPooler=this;
    }

    public GameObject playParticle(){
        return particals.getPooledObject();
    }
}
