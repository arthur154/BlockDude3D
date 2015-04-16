using UnityEngine;
using System.Collections;

public class VictoryScreenScript : MonoBehaviour {
	public Texture2D Background;

	// Use this for initialization
	void Start () {
		// Player won the game, delete all previous progress for new game!
		PlayerPrefs.DeleteAll();
		// Show cursor
		Screen.showCursor=true;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// GUI Code
	void OnGUI () {
		// Draw the background
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Background);
		// Start main button area
		GUILayout.BeginArea(new Rect(Screen.width/2-75,3*Screen.height/4+50,150,300));
		// New Game button
		if(GUILayout.Button("New Game")){
			// Check to see if game data can be cleared
			StartNewGame();
		}
		// Quit button
		if(GUILayout.Button("Quit")){
			Application.Quit();
		}
		GUILayout.EndArea();
	}
	
	void StartNewGame(){
		// Create values for the saved game variables
		PlayerPrefs.SetInt("HasGameData",1);
		PlayerPrefs.SetInt("GreatestLevel",1);
		// Start Game
		LoadLevel(1);
	}
	
	void LoadLevel(int LevelNumber){
		Application.LoadLevel("Level"+ LevelNumber);	
	}
}
