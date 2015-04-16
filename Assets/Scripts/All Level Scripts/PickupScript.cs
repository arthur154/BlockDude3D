using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {
	public Texture2D aimerOn;
	public Texture2D aimerOff;
	public GameObject player;
	private bool holdingBox = false;
	private GameObject box;
	
	// Use this for initialization
	void Start () {
	}
	
	void OnGUI () {
		if (Time.timeScale>0){
			RaycastHit hit = new RaycastHit();
			Ray ray = new Ray(transform.position, transform.forward);
			bool somethingHit = Physics.Raycast(ray,out hit, 2.0f);
			bool wasBox=false; 
			if (somethingHit) wasBox=(hit.collider.gameObject.name=="Box");
			
			if (wasBox || holdingBox) {
				// Draw aimerOn
				GUI.DrawTexture(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),aimerOn);
			}
			else {
				// Draw aimerOff
				GUI.DrawTexture(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),aimerOff);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			if (holdingBox){
				// Get the box's current position and calculate a new desired position
				box.transform.localPosition=new Vector3(0.0f,0.0f,1.0f);	
				Vector3 desiredPosition=new Vector3(box.transform.position.x,transform.position.y,box.transform.position.z);
				// Unparent the box and reset it's collision values
				box.transform.parent=null;
				//box.transform.rotation=new Quaternion(0f,0f,0f,0f);
				box.rigidbody.useGravity=true;
				box.collider.enabled=true;				
				holdingBox=false;
				// Update the box's final position
				box.transform.position=desiredPosition;
				// Turn the holding collider off
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit = new RaycastHit();
			Ray ray = new Ray(transform.position, transform.forward);
			if(Physics.Raycast(ray,out hit, 2.0f)){
				if (hit.collider.gameObject.name=="Box") {
					// If there is a gameObject named box that is hit by the raycast make the player pick it up
					box = hit.collider.gameObject;
					box.transform.parent=transform;
					box.rigidbody.useGravity=false;
					box.collider.enabled=false;
					holdingBox=true;
					// Turn the holding collider on
				}
			}
		}
		if (holdingBox) {
			// Adjust the position of the box so it remains in one place
			box.transform.localPosition=new Vector3(0f,-1f,0.75f);

			//box.transform.localRotation=new Quaternion(0f,0f,0f,1f);
			
			// change box to not rotate when picked up, allows easier block placement
			box.transform.rotation=new Quaternion(0f,0f,0f,1f);
		}
	}
}
