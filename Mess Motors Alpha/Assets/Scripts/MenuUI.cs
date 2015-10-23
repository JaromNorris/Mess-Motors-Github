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
        Application.LoadLevel(3);
    }

    public void ShowPlayerSelect()
    {
    }

    public void StartGame()
    {

        Application.LoadLevel(levelselect);
    }

    public void LoadLevel (int level)
    {
        Application.LoadLevel(level);
    }

    public void Play()
    {
    }

}
