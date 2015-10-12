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

	public char GetColor()
	{
		string colour = rend.color.ToHexStringRGB ();
		if (colour == "FFFF00")
			return 'y';
		else if (colour == "FF0000")
			return 'r';
		else if (colour == "0000FF")
			return 'b';
		else if (colour == "00FF00")
			return 'g';
		else if (colour == "FF7700")
			return 'o';
		else if (colour == "FFFFFF")
			return 'n';
		else
			print ("GetColor failure. Color returned was: " + colour);
		return '0';
	}
}
