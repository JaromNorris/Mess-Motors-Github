using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryMenuUi : MonoBehaviour {

    public GameObject Restartbutton;
    public GameObject MMbutton;
    private string win = Controller.winner;
    public GameObject Display;

	public Sprite red;
	public Sprite blue;
	public Sprite green;
	public Sprite yellow;

    public void ShowMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Restart()
    {
        Application.LoadLevel(4);
    }

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }

    // Use this for initialization
    void Start () {
        //Display.GetComponent<Text>().text = win;
		if (win == "Red!")
			Display.GetComponent<SpriteRenderer> ().sprite = red;
		else if (win == "Blue!")
			Display.GetComponent<SpriteRenderer> ().sprite = blue;
		else if (win == "Green!")
			Display.GetComponent<SpriteRenderer> ().sprite = green;
		else if (win == "Orange!")
			Display.GetComponent<SpriteRenderer> ().sprite = yellow;

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Submit") > 0)
			Restart ();
		if (Input.GetAxis ("Cancel") > 0)
			ShowMainMenu();
	}
}
