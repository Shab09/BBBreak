using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystemGenerator : MonoBehaviour
{   
    public static BlockSystemGenerator blockSystemGenerator;// Globel Reference to the system
    public GameObject generator;//Object to generate
    public Vector3 generationPosition = new Vector3(0,21,0);
    private void Start() {
        //Make sytem accessable
        blockSystemGenerator=this;
    }
    public void Genrate(){
        GameObject temp=Instantiate(generator); // Create new gameobject
        temp.GetComponent<GenerateBlocks>().setnewPosition(generationPosition);// set objects position
    }
}
