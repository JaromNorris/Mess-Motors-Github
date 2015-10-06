using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public int frameWidth = 1920;
	public int frameHeight = 1080;
    private int boxSize = 60;
    public float timer;
    public GameObject timerObj;


	public Transform paintBox;

	void Awake () {
        int rows = frameHeight / boxSize;
		int cols = frameWidth / boxSize;
		for (int y = 0; y < rows; y++) {
			for (int x = 0; x < cols; x++) {
				Vector3 pos = new Vector3 (x * (boxSize/100.0f) - frameWidth/200.0f, 
				                           y * (boxSize/100.0f) - frameHeight/200.0f, 
				                           0f);
				Instantiate (paintBox, pos, Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("r"))
        { //resets the game if the r key is hit
            Application.LoadLevel(Application.loadedLevel);

      }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else { timer = 0; }
        
        timerObj.GetComponent<Text>().text = timer.ToString();

    }
}

