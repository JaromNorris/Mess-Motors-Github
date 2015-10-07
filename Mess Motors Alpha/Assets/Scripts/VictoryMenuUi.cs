using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryMenuUi : MonoBehaviour {

    public GameObject Restartbutton;
    public GameObject MMbutton;

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
