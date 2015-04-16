using UnityEngine;
using System.Collections;

public class BoxBehaviorScript : MonoBehaviour {
	private Vector3 origPos;
	
	// Use this for initialization
	void Start () {
		origPos=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// If the box is too far off the map respawn it
		if (transform.position.y < -10) 
		{
			transform.position=origPos;
			transform.rotation=new Quaternion(0,0,0,1);
		}
		
		// constantly be setting box rotation to null
		transform.rotation=new Quaternion(0,0,0,1);
	}
}
