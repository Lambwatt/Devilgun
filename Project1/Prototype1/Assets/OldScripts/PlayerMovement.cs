using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public float walkSpeed = 4f;
	public float runSpeed = 8f;
	public float jumpForce = 20f;

	private bool walk = true;
	private bool grounded = true;
	private Rigidbody move;


	// Use this for initialization
	void Start () {
		move = GetComponent<Rigidbody> ();


	}
	
	// Update is called once per frame
	void Update () {

		ToggleRun ();


		if (walk) {
			Walk();
		} else if (!walk) {
			Run();
		}

		Jump ();

	}

	void FixedUpdate(){
/*
		ToggleRun ();
		
		
		if (walk) {
			Walk();
		} else if (!walk) {
			Run();
		}
		
		Jump ();
*/
	}

	void ToggleRun(){
		if (CrossPlatformInputManager.GetButtonDown ("Caps") && walk) {
			walk = false;
		} else if (CrossPlatformInputManager.GetButtonDown ("Caps") && !walk) {
			walk = true;
		}
	}

	void Walk(){
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		move.velocity = new Vector3((h * walkSpeed), 0, 0);
	}

	void Run(){
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		move.velocity = new Vector3((h * runSpeed), 0, 0);
	}

	void Jump(){
		Vector3 up = new Vector3 (0, 1, 0);

		if (CrossPlatformInputManager.GetButton ("Jump")) {
			move.AddForce((up *jumpForce) , ForceMode.Impulse);
		}

	}


}
