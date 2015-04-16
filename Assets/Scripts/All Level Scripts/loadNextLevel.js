#pragma strict

function Start () {

}

function OnTriggerEnter (other : Collider) {
	// If we hit the goal advance to the next level in the build
	if (other.gameObject.name=="Goal" || other.gameObject.name=="CheatGoal") 
		Application.LoadLevel(Application.loadedLevel+1);
		
	// If we hit the last goal go to a win GUI then go home
	else if (other.gameObject.name=="Win") {
		print("Win");
		Application.LoadLevel("VictoryScreen");
	}
}
