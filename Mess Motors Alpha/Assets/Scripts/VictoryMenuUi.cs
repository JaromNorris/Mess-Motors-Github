using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryMenuUi : MonoBehaviour {

    public GameObject Restartbutton;
    public GameObject MMbutton;
    private string win = Controller.winner;
    public GameObject Display;

    public void ShowMainMenu()
    {
        Application.LoadLevel(1);
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }

    // Use this for initialization
    void Start () {
        Display.GetComponent<Text>().text = win;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
