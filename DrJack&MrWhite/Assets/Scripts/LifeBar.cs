﻿using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {


    private const float SPEED = 1.0f;

    public GameObject fill;

    public int value;
    public int maxValue;
    public int minValue;
    public CharacterScript character;
    public PickUpController pickupController;

    private float targetScale,currentScale;

    private bool AudioPlayed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.value = character.score_life;
        if (this.value >= 0)
            this.targetScale = Mathf.Clamp(((this.maxValue - this.value) / (float)(this.maxValue - this.minValue)), 0, 1);
        else
        {
            if (!AudioPlayed)
            {
                this.audio.Play();
                this.AudioPlayed = true;
            }
            this.targetScale = 100;
        }

        if (this.currentScale < this.targetScale)
        {
            this.currentScale += SPEED * Time.deltaTime;
            if (this.currentScale > this.targetScale)
                this.currentScale = targetScale;
        }
        else if (this.currentScale > this.targetScale)
        {
            this.currentScale -= SPEED * Time.deltaTime;
            if (this.currentScale < this.targetScale)
                this.currentScale = targetScale;
        }

        if (this.targetScale == 100)
            this.fill.GetComponent<sc_HUEShift>().startColor = new Color(this.fill.GetComponent<sc_HUEShift>().startColor.r, this.fill.GetComponent<sc_HUEShift>().startColor.g, this.fill.GetComponent<sc_HUEShift>().startColor.b, 0.5f + ((float)(2.5f - this.currentScale) / 2.5f));


        this.fill.transform.localScale = new Vector2(this.currentScale, this.currentScale);
        //Debug.Log(currentScale);
        if (currentScale > 2.6f)
        {
           
            this.pickupController.gameObject.SetActive(false);
            GameObject.Find("FinalScore").GetComponent<ScoreContainer>().score = (int)character.Score_points;
            DontDestroyOnLoad(GameObject.Find("FinalScore"));
            Application.LoadLevel("gameOver");
        }

        //if (xScale >= 0.3f)
        //    this.fill.GetComponent<SpriteRenderer>().color = Color.green;
        //else
        //    this.fill.GetComponent<SpriteRenderer>().color = Color.red;


	
	}
}
