using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public int frameWidth = 1920;
	public int frameHeight = 1080;
    private int boxSize = 60;
    public float timer;
    public GameObject timerObj;

	private PaintBox[,] paintArray;


	public Transform paintBox;

	void Awake () {
        int rows = frameHeight / boxSize;
		int cols = frameWidth / boxSize;
		paintArray = new PaintBox[rows,cols]; //REMEMER THIS ARRAY IS IN FORM [Y,X]
		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				Vector3 pos = new Vector3 (x * (boxSize/100.0f) - frameWidth/200.0f, 
				                           y * (boxSize/100.0f) - frameHeight/200.0f, 
				                           0f);
				paintArray[y, x] = Instantiate (paintBox, pos, Quaternion.identity) as PaintBox;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("r"))
        { //resets the game if the r key is hit
            Application.LoadLevel(0);

      }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else { timer = 0; }
        
        timerObj.GetComponent<Text>().text = timer.ToString();

        if(timer == 0)
        {
			//print ("Winner is: " + getWinner());
			Application.LoadLevel(2);
        }

    }

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

