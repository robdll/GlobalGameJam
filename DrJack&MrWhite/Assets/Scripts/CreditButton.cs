﻿using UnityEngine;
using System.Collections;

public class CreditButton : MonoBehaviour {

    public StartScreen startScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (this.startScreen.currentMode == StartScreen.Mode.Credits)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.collider2D.enabled = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.collider2D.enabled = true;
        }
	}
	

    void OnMouseDown()
    {
        if(this.startScreen.currentMode == StartScreen.Mode.Title)
            this.startScreen.currentMode = StartScreen.Mode.Credits;
    }
}
