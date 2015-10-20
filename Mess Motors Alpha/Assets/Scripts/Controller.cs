using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public int frameWidth = 1920;
	public int frameHeight = 1080;
    private int boxSize = 24;
	public int paintRadius = 3;

    public float timer;
    private float spawnx = 0;
    private float spawny = 0;//these floats designate the next spot to respawn. will be changed by spawnPlayers
    private int spawn;
    private Vector3 sp;
    public GameObject timerObj;
    public static string winner;

    public GameObject[] spawnPoints;//make an array of all viable spawn points. Can be readded for each level with minimal difference
    
	private GameObject[] players;
	public GameObject playerObject; 
	public int numberOfPlayers = 1;

    private PaintBox[,] paintArray;
	public GameObject paintBox;

	void Awake () 
	{
		createPlayers ();
		createPaintGrid ();
	}

	void createPlayers()
	{
		players = new GameObject[5];
        //Vector3 pos = new Vector3 (0f, 0f, 0f);
        Vector3 pos;
        for (int i = 0; i < numberOfPlayers; i++) {
            pos = RandomSpawn();
            players[i] = (Instantiate(playerObject, pos, Quaternion.identity)) as GameObject;
			players[i].GetComponent<Driver>().PlayerSetup(i);
			//SpawnPlayer(players[i]);
		}
	}

	void createPaintGrid()
	{
		int rows = frameHeight / boxSize;
		int cols = frameWidth / boxSize;
		paintArray = new PaintBox[rows,cols]; //REMEMBER THIS ARRAY IS IN FORM [Y,X]
		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				Vector3 pos = new Vector3 (((x*boxSize)-(frameWidth/2f))/100f, 
				                           ((y*boxSize)-(frameHeight/2f))/100f, 
				                           0f);
				GameObject box = (Instantiate (paintBox, pos, Quaternion.identity)) as GameObject;
				paintArray[y, x] = box.GetComponent<PaintBox>();
			}
		}
	}

    //void SpawnPlayer(GameObject car) //Needs to take a player number as a parameter, and all it does is set its x and y positions.
    //{
      //  print("Spawn Called");
        //spawn = Random.Range(0, spawnPoints.Length);
       // spawnx = spawnPoints[spawn].GetComponent<Transform>().position.x;
      //  spawny = spawnPoints[spawn].GetComponent<Transform>().position.y;
   // }
    Vector3 RandomSpawn()
    //picks a random point from our 'safe' spawn list. Safe spawns are marked by small invisible boxes, turn on their sprite renderer to see location.
    {
        spawn = Random.Range(0, spawnPoints.Length);
        spawnx = spawnPoints[spawn].GetComponent<Transform>().position.x;
        spawny = spawnPoints[spawn].GetComponent<Transform>().position.y;
        sp = new Vector3(spawnx, spawny, 0f);
        return sp;
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

		paintGround ();

    }

	void paintGround()
	{
		foreach (GameObject car in players) {
			if (car == null)
				return;
			float xPos = car.GetComponent<Transform>().position.x;
			float yPos = car.GetComponent<Transform>().position.y;
			int xVal = (int)((xPos + (frameWidth/200f))/(boxSize/100f));
			int yVal = (int)((yPos + (frameHeight/200f))/(boxSize/100f));

			for (int x = -paintRadius; x <= paintRadius; x++) {
				for (int y = -paintRadius; y <= paintRadius; y++) {
					if (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow (y, 2)) <= paintRadius)
						paintArray[yVal+y,xVal+x].ChangeColor(car.GetComponent<Driver>().c);
				}
			}
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
        {
            winner = "y";
            return "Yellow";
        }
        else if (r == winScore)
        {
            winner = "r";
            return "Red";
        }
        else if (b == winScore)
        {
            winner = "b";
            return "Blue";
        }
        else if (g == winScore)
        {
            winner = "g";
            return "Green";
        }
        else if (o == winScore)
        {
            winner = "o";
            return "Orange";
        }

        winner = "Error";
		return "Error";
	}
}

