using UnityEngine;
using System.Collections;

public class PlayerSelectBox : MonoBehaviour {
	
	public int playerNum;
	public GameObject carDisplay;
	public GameObject okay;
	public Sprite[] cars;


	public bool active = false;
	public bool finalized = true;
	private bool left;
	private string button;
	private string vertical;
	private int carChoice = 0;
	private bool canSwitch = false;
	private bool canSelect = true;

	// Use this for initialization
	void Start () {
		if (playerNum == 1) {
			button = "P1Accel";
			vertical = "P1Vertical";
			left = true;
		} else if (playerNum == 2) {
			button = "P2Accel";
			vertical = "P2Vertical";
			left = false;
		} else if (playerNum == 3) {
			button = "P3Accel";
			vertical = "P3Vertical";
			left = true;
		} else if (playerNum == 4) {
			button = "P4Accel";
			vertical = "P4Vertical";
			left = false;
		} else if (playerNum == 0) {
			button = "KeyboardAccel";
			vertical = "KeyboardVertical";
			left = true;
		}

		carDisplay.GetComponent<SpriteRenderer> ().sprite = cars [carChoice];
	}
	
	// Update is called once per frame
	void Update () {
		//Listen for A and B to change the player state.
		if (Input.GetAxis (button) > 0.2 && canSelect == true) {
			if (active == false) {
				active = true;
				finalized = false;
			} else if (finalized == false) {
				finalized = true;
				okay.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			}
			canSelect = false;
		} else if (Input.GetAxis (button) < -0.2 && canSelect == true) {
			if (finalized == false) {
				active = false;
				finalized = true;
			} else if (finalized == true) {
				finalized = false;
				okay.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			}
			canSelect = false;
		} else if (Input.GetAxis(button) > -0.2 && Input.GetAxis(button) < 0.2) {
			canSelect = true;
		}
		 //Move the object into position if it's not already.
		float pos = gameObject.GetComponent<Transform> ().position.x;
		if (active == true) {
			if (left) {
				if (pos < -6.5f)
					transform.Translate(new Vector3(.2f, 0, 0));
			} else {
				if (pos > 6.5f)
					transform.Translate(new Vector3(-.2f, 0, 0));
			}
		} else {
			if (left) {
				if (pos > -11.5f)
					transform.Translate(new Vector3(-.2f, 0, 0));
			} else {
				if (pos < 11.5f)
					transform.Translate(new Vector3(.2f, 0, 0));
			}
		}

		//Allow the player to select their car.
		if (Input.GetAxis (vertical) > 0.2 && finalized == false) {
			if (canSwitch) {
				carChoice--;
				if (carChoice == -1)
					carChoice = 5;
				carDisplay.GetComponent<SpriteRenderer> ().sprite = cars [carChoice];
				canSwitch = false;
			}
		} else if (Input.GetAxis (vertical) < -0.2 && finalized == false) {
			if (canSwitch) {
				carChoice++;
				if (carChoice == 6)
					carChoice = 0;
				carDisplay.GetComponent<SpriteRenderer> ().sprite = cars [carChoice];
				canSwitch = false;
			}
		} else {
			canSwitch = true;
		}

	}
}
