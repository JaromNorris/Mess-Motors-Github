using UnityEngine;
using System.Collections;

public class PlayerSelectScreen : MonoBehaviour {

	public GameObject[] boxes = new GameObject[5];

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Start") > 0) 
		{
			int count = 0;
			foreach (GameObject o in boxes)
			{
				if (!o.GetComponent<PlayerSelectBox>().finalized)
					return;
				if (o.GetComponent<PlayerSelectBox>().active)
					count++;
			}

			if (count > 1)
			{
				transferData ();
				Application.LoadLevel (4);
				return;
			}
		}
	}

	void transferData()
	{
		for (int i = 0; i < 5; i++) 
		{
			Controller.carData [i].active = boxes [i].GetComponent<PlayerSelectBox> ().active;
			Controller.carData [i].sprite = boxes [i].GetComponent<PlayerSelectBox> ().
				carDisplay.GetComponent<SpriteRenderer> ().sprite;
		}
	}
}
