﻿using UnityEngine;
using System.Collections;



public class Driver : MonoBehaviour {
	
	public float maxSpeed = .3f;
	public float currentSpeed = 0;
	public Color c;
	public int playerNumber;
	public Sprite splat;
	public Sprite car;

	private GameObject controller = Controller.instance;

	private string horControl = "KeyboardHorizontal";
	private string accelControl = "KeyboardAccel";

	private bool isDead = false;

	// Use this for initialization
	void Awake () {

	}

	public void PlayerSetup(int playNum)
	{
		playerNumber = playNum;

		if (playerNumber == 0) {
			c = new Color (1f, 1f, 0f, .2f);
		} else if (playerNumber == 1) {
			c = new Color (1f, 0f, 0f, .2f);
			horControl = "P1Horizontal";
			accelControl = "P1Accel";
		} else if (playerNumber == 2) { 
			c = new Color (0f, 0f, 1f, .2f);
			horControl = "P2Horizontal";
			accelControl = "P2Accel";
		} else if (playerNumber == 3) {
			c = new Color (0f, 1f, 0f, .2f);
			horControl = "P3Horizontal";
			accelControl = "P3Accel";
		} else if (playerNumber == 4) {
			c = new Color (1f, .5f, 0f, .2f);
			horControl = "P4Horizontal";
			accelControl = "P4Accel";
		}
	}

    void OnTriggerEnter2D(Collider2D other)//triggers should be dying and powerups
    {
		print ("Trigger Enter");
		if (other.tag == "Hazard") {
			playerDeath ();
		}
    }
	
	// Update is called once per frame
	void Update () {
        if (GameStart.startGame || isDead) { return; }
        //if the game start countdown is still going, freezes the player's movement by returning before
        //button presses are assessed

			float rotate = Input.GetAxisRaw (horControl);
			transform.Rotate (0, 0, -rotate*2);

			if (Input.GetAxis(accelControl) > 0) {
				if (currentSpeed < maxSpeed)
					currentSpeed += .02f;
			} else if (Input.GetAxis (accelControl) < 0) {
				if (currentSpeed > 0)
					currentSpeed -= .04f;
				else if (currentSpeed > (0 - maxSpeed))
					currentSpeed -= .01f;
			} else if (Input.GetAxis(accelControl) == 0) {
				if (currentSpeed > 0)
					currentSpeed -= .02f;
				else if (currentSpeed < 0)
					currentSpeed += .01f;
				else
					currentSpeed = 0;
			}
        
		float xDir = (Mathf.Cos (transform.rotation.z * Mathf.Deg2Rad) * currentSpeed);
		float yDir = (Mathf.Sin (Mathf.Deg2Rad * transform.rotation.z) * currentSpeed);

        transform.Translate (new Vector3 (xDir, yDir, 0));

	}

	void playerDeath()
	{
		gameObject.GetComponent<SpriteRenderer> ().sprite = splat;
		isDead = true;
		StartCoroutine ("wait");
	}

	public IEnumerator wait()
	{
		yield return new WaitForSeconds (3f);
		gameObject.GetComponent<Transform> ().position = new Vector3 (-1000, -1000, 0);
		yield return new WaitForSeconds (3f);
		gameObject.GetComponent<Transform> ().position = 
			controller.gameObject.GetComponent<Controller>().RandomSpawn ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = car;
		isDead = false;
	}

}