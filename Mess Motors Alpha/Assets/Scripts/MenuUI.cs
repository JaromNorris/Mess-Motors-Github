using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuUI : MonoBehaviour {

    public GameObject Start;
    public GameObject Levels;
    public GameObject Players;
    public static int levelselect;

    public void ShowLevelSelect()
    {
        Application.LoadLevel(2);
    }

    public void ShowPlayerSelect()
    {
		//Application.LoadLevel (1);
    }

    public void StartGame()
    {
		Application.LoadLevel (1);
        //Application.LoadLevel(levelselect);
    }

    public void LoadLevel (int level)
    {
        Application.LoadLevel(level);
    }

    public void Play()
    {
    }

	void Update()
	{
		if (Input.GetAxis ("Start") > 0)
			StartGame ();
	}
}
