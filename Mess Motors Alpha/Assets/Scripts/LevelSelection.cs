using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {

    void setLevel(int i)
    {
        MenuUI.levelselect = i;
    }

    public void click0()//"Playground" level
    {
        setLevel(0);
    }


    public void click4()//This is where I'd put our next level.... IF WE HAD ONE
    {
        setLevel(4);
    }

    public void ShowMainMenu()
    {
        Application.LoadLevel(1);
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
