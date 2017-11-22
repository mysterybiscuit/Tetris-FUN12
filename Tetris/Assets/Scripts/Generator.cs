using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public List<GameObject> tetrominos = new List<GameObject>();
    
    // Use this for initialization
	void Start () {
        generateNextTetromino();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void generateNextTetromino()
    {
        int random = Random.Range(0, tetrominos.Count);

        Instantiate(tetrominos[random], transform.position, Quaternion.identity);
        //Generates tetromino at the spawn position with default rotation.

    }
}
