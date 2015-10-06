using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuUI : MonoBehaviour {

    public GameObject Start;
    public GameObject Levels;
    public GameObject Players;

    public void ShowLevelSelect()
    {
        //start off, players off, levels on
    }

    public void StartGame()
    {
        Application.LoadLevel(0);
        Debug.Log("westarted");
        //start on, players off, levels off
    }

    public void LoadLevel (int level)
    {
        Application.LoadLevel(level);
    }

    public void Play()
    {
        //start off, players on, levels off
    }

}
