using UnityEngine;
using System.Collections;

public class GroundDetection : MonoBehaviour {

	private PlayerMovement player; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerMovement> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//When triggered sets player as grounded	
	void OnTriggerEnter(){
		player.OnGround ();
	}
	//when triggered sets player as not grounded
	void OnTriggerExit(){
		player.OffGround ();
	}

}
