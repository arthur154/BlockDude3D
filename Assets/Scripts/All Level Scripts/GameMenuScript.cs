using UnityEngine;
using System.Collections;

public class GameMenuScript : MonoBehaviour {
	public GameObject player;
	public GameObject playerCamera;
	public Texture2D GamePaused;
	public Texture2D ControlBG;
	public Texture2D Controls;
	
	private bool showControls=false;
	
	// Use this for initialization
	void Start () {
		// Update PlayerPrefs -> "GreatestLevel"
		PlayerPrefs.SetInt("GreatestLevel",Application.loadedLevel);
		Time.timeScale=1.0f;
		Screen.showCursor=false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// GUI code
	void OnGUI() {
		// If the game isn't paused then GUI
		if(Time.timeScale==0) {
			// Draw background
			GUI.Box(new Rect(5,5,Screen.width-10,Screen.height-10), "");
			
			if (showControls) {
				GUI.DrawTexture(new Rect(Screen.width/2-300,25,600,Screen.height-50), ControlBG);
				GUI.DrawTexture(new Rect(Screen.width/2-250,50,500,Screen.height-200), Controls);
				if(GUI.Button(new Rect(Screen.width/2-75,Screen.height-100,150,50),"Back")) showControls=false;
			}
			else {
				// Game Paused text
				GUI.DrawTexture(new Rect(Screen.width/2-400,Screen.height/2-75,800,150),GamePaused);
				
				// Start main button area
				GUILayout.BeginArea(new Rect(Screen.width/2-75,3*Screen.height/4,150,300));
					if(GUILayout.Button("Resume")){
						// Resume the game
						Time.timeScale=1.0f;
						Screen.showCursor=false;
						// Disable the player control script
						player.GetComponent<MouseLook>().enabled=true;
						playerCamera.GetComponent<MouseLook>().enabled=true;
						playerCamera.GetComponent<PickupScript>().enabled=true;
						// Play the music
						player.GetComponent<AudioSource>().Play();
					}
					if(GUILayout.Button("Controls")){
						showControls=true;
					}
					if(GUILayout.Button("Save and Quit")){
						Application.LoadLevel("GameStart");
					}
				GUILayout.EndArea();
			}
		}
	}
}
