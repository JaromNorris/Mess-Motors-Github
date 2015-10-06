using UnityEngine;
using System.Collections;

//This is the invisible boundary around the play area that prevents the car from leaving it.
//[System.Serializable]
//public class Boundary
//{    public float xMin, xMax, yMin, yMax;}

public class Driver : MonoBehaviour {
	
	public float maxSpeed = .3f;
	public float currentSpeed = 0;
    //public Boundary boundary;
	public Color c;
	public int playerNumber;

	// Use this for initialization
	void Awake () {
		if (playerNumber == 0)
			c = new Color (1f, 1f, 0f, .2f);
		else if (playerNumber == 1)
			c = new Color (1f, 0f, 0f, .2f);
		else if (playerNumber == 2)
			c = new Color (0f, 0f, 1f, .2f);
		else if (playerNumber == 3)
			c = new Color (0f, 1f, 1f, .2f);
		else if (playerNumber == 4)
			c = new Color (1f, .5f, 0f, .2f);

	}
	
	// Update is called once per frame
	void Update () {
		string horControl = "KeyboardHorizontal";
		string accelControl = "KeyboardAccel";

		if (playerNumber == 1) {
			horControl = "P1Horizontal";
			accelControl = "P1Accel";
		} else if (playerNumber == 2) {
			horControl = "P2Horizontal";
			accelControl = "P2Accel";
		} else if (playerNumber == 3) {
			horControl = "P3Horizontal";
			accelControl = "P3Accel";
		} else if (playerNumber == 4) {
			horControl = "P4Horizontal";
			accelControl = "P4Accel";
		}

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

        //adding in the clamp function, which prevents the player 
        //from making their position something outside our bounds. 
        //xDir = Mathf.Clamp(xDir, boundary.xMin, boundary.xMax);
        //yDir = Mathf.Clamp(yDir, boundary.yMin, boundary.yMax);
        transform.Translate (new Vector3 (xDir,
            yDir, 0));

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "PaintBox") {
			print("Collision");
			PaintBox box = coll.gameObject.GetComponent<PaintBox>();
			box.ChangeColor (c);
		}
	}
}