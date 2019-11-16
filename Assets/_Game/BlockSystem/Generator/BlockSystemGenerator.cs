using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystemGenerator : MonoBehaviour
{   
    public static BlockSystemGenerator blockSystemGenerator;
    public GameObject generator;
    
    private void Start() {
        blockSystemGenerator=this;
    }
    public void Genrate(){
        GameObject temp=Instantiate(generator);
        temp.transform.position = transform.position;
    }
}
