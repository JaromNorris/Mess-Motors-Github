using UnityEngine;
using System.Collections;

public class PaintBox : MonoBehaviour {

	private SpriteRenderer rend;
	// Use this for initialization
	void Awake () {
		rend = gameObject.GetComponent<SpriteRenderer> ();
		rend.color = new Color(1f,1f,1f,.1f);
	}

	public void ChangeColor(Color c)
	{
		rend.color = c;
	}
}
