using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour {
    public float delayMovement = 0.5f;
    private Movement move;
    private float randomX;
    private float randomY;

    // Use this for initialization
    void Start () {
        move = GetComponent<Movement>();
        StartCoroutine("GenerateMovement");
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator GenerateMovement(){
        while(enabled){
            randomX = Random.Range(-1f, 1f);
            randomY = Random.Range(-1f, 1f);
            move.movement = new Vector2(randomX, randomY);
            yield return new WaitForSeconds(delayMovement);
            //Wait while script is disabled
            yield return new WaitUntil(() => enabled == true);
        }
    }
}
