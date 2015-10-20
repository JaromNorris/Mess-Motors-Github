﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public int frameWidth = 1920;
	public int frameHeight = 1080;
    private int boxSize = 60;
    public float timer;
    public GameObject timerObj;
    public GameObject[] spawnPoints;//make an array of all viable spawn points. Can be readded for each level with minimal difference
    public GameObject playerObject; //This is in order to spawn... not sure how this will work once we have different player sprites, but we'll figure it out
	
    private PaintBox[,] paintArray;


	public GameObject paintBox;

	void Awake () {
        SpawnPlayer();
        SpawnPlayer();
        int rows = frameHeight / boxSize;
		int cols = frameWidth / boxSize;
		paintArray = new PaintBox[rows,cols]; //REMEMER THIS ARRAY IS IN FORM [Y,X]
		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				Vector3 pos = new Vector3 (x * (boxSize/100.0f) - frameWidth/200.0f, 
				                           y * (boxSize/100.0f) - frameHeight/200.0f, 
				                           0f);
				GameObject box = (Instantiate (paintBox, pos, Quaternion.identity)) as GameObject;
				paintArray[y, x] = box.GetComponent<PaintBox>();
			}
		}
	}

    void SpawnPlayer()
    {
        print("Spawn Called");
        int spawn = Random.Range(0, spawnPoints.Length);
        //picks a random spawn point to instantiate the player at. Currently no anti-collision detection
        //anti-collision for start game could just return an int for which spot was chosen for P1 and forbid that from P2's random?
        GameObject.Instantiate(playerObject, spawnPoints[spawn].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {


        //Should be removed before Feature Complete is done. For testing purposes still here.
        if (Input.GetKey("r"))
        { //resets the game if the r key is hit
            Application.LoadLevel(0);

      }
        if (GameStart.startGame == false)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else { timer = 0; }
        }
        
        timerObj.GetComponent<Text>().text = timer.ToString();

        if(timer == 0)
        {
			print ("Winner is: " + getWinner());
			Application.LoadLevel(2);
        }

    }

	//Counts up all of the paintboxes and returns the String Name
	//of the color that has the most boxes.
	public string getWinner()
	{
		//Variables to count squares.
		int y = 0;
		int r = 0;
		int b = 0;
		int g = 0;
		int o = 0;
		int n = 0;

		foreach (PaintBox box in paintArray) {
			switch (box.GetColor())
			{
			case 'y':
				y++;
				break;
			case 'r':
				r++;
				break;
			case 'b':
				b++;
				break;
			case 'g':
				g++;
				break;
			case 'o':
				o++;
				break;
			case 'n':
				n++;
				break;
			}
		}

		int winScore = Mathf.Max (y, r, b, g, o);

		if (y == winScore)
			return "Yellow";
		else if (r == winScore)
			return "Red";
		else if (b == winScore)
			return "Blue";
		else if (g == winScore)
			return "Green";
		else if (o == winScore)
			return "Orange";

		return "Error";
	}
}

