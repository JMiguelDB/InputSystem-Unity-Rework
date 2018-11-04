using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector2 movement;
    public float distance = 10f;
	// Use this for initialization
	void Start () {
        movement = new Vector2(0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(movement * Time.deltaTime * distance);
        movement = new Vector2(0, 0);
    }
}
