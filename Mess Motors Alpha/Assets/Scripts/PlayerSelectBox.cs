using UnityEngine;
using System.Collections;

public class PlayerSelectBox : MonoBehaviour {
	
	public int playerNum;
	public GameObject carDisplay;
	public Sprite[] cars;

	public bool active = false;
	public bool left;
	private string button;
	private string vertical;
	private int carChoice = 0;

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
		if (Input.GetAxis (button) > 0)
			active = true;
		else if (Input.GetAxis (button) < 0)
			active = false;

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

		if (Input.GetAxis (vertical) > 0) {
			carChoice--;
			if (carChoice == -1)
				carChoice = 5;
			carDisplay.GetComponent<SpriteRenderer> ().sprite = cars [carChoice];
		}
		else if (Input.GetAxis(vertical) < 0) {
			carChoice++;
			if (carChoice == 6)
				carChoice = 0;
			carDisplay.GetComponent<SpriteRenderer> ().sprite = cars [carChoice];
		}

	}
}
