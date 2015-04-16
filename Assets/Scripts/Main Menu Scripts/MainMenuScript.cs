using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	public Texture2D Background;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// GUI Code
	void OnGUI () {
		// Draw the background
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Background);
		// Start main button area
		GUILayout.BeginArea(new Rect(Screen.width/2-75,3*Screen.height/4,150,300));
		// New Game button
		if(GUILayout.Button("New Game")){
			// Check to see if game data can be cleared
			StartNewGame();
		}
		// Continue Game button
		if(GUILayout.Button("Continue Game")){
			ContinueGame();
		}
		// Clear Saves button
		if(GUILayout.Button("Clear Saved Game")){
			PlayerPrefs.DeleteAll();
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
	
	void ContinueGame(){
		int greatestLevel = PlayerPrefs.GetInt("GreatestLevel",0);
		if(greatestLevel > 1){
			LoadLevel(greatestLevel);
		}
	}
	
	void LoadLevel(int LevelNumber){
		Application.LoadLevel("Level"+ LevelNumber);	
	}
}
