using UnityEngine;
using System.Collections;

public class Lv1StartScript : MonoBehaviour {
	public GameObject player;
	public GameObject playerCamera;
	public GameObject playerControls;
	public Texture2D instructions;
	public Texture2D instructionsBG;
	private bool start=false;

	// Use this for initialization
	void Start () {
		// Disable the player control script
		player.GetComponent<MouseLook>().enabled=false;
		playerCamera.GetComponent<MouseLook>().enabled=false;
		playerCamera.GetComponent<PickupScript>().enabled=false;
		playerControls.GetComponent<PlayerControlsScript>().enabled=false;
		// Pause the music
		player.GetComponent<AudioSource>().Pause();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		if(!start) {
			// Pause game
			Screen.showCursor=true;
			
			// Create instructions
			GUI.DrawTexture(new Rect(Screen.width/2-400,25,800,Screen.height-50), instructionsBG);
			GUI.DrawTexture(new Rect(Screen.width/2-350,50,700,Screen.height-200), instructions);
			// Create button to proceed
			if(GUI.Button(new Rect(Screen.width/2-50,3*Screen.height/4,100,50),"Ok")) {
				// Resume the game
				Screen.showCursor=false;
				// Disable the player control script
				player.GetComponent<MouseLook>().enabled=true;
				playerCamera.GetComponent<MouseLook>().enabled=true;
				playerCamera.GetComponent<PickupScript>().enabled=true;
				playerControls.GetComponent<PlayerControlsScript>().enabled=true;
				// Play the music
				player.GetComponent<AudioSource>().Play();
				start=true;
			}
		}
	}
}
