using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuUI : MonoBehaviour {

    public GameObject Start;
    public GameObject Levels;
    public GameObject Players;

    public void ShowLevelSelect()
    {
    }

    public void ShowPlayerSelect()
    {
    }

    public void StartGame()
    {
        Application.LoadLevel(0);
    }

    public void LoadLevel (int level)
    {
        Application.LoadLevel(level);
    }

    public void Play()
    {
    }

}
