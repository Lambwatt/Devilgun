using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	
	public float jumpStrength;
	public float maxFallSpeed;
	
	private Rigidbody2D rb;
	int rotations;
	bool falling;
	Vector2 start;
	private Collider2D floorCheck;// = transform.gameObject;
	public bool grounded = false;
	private GameObject player;
	private moveLeftOrRight movement;
	//private bool jumping = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		falling = false;
		rotations = 8;
		player = GameObject.FindGameObjectWithTag ("Player");
		movement = player.GetComponent<moveLeftOrRight> ();
	}

	//Called at initialization of game
	public void land(){
		//Debug.Log("landing");
		//if(!jumping){
		grounded = true;
		//Debug.Log ("Landed");
		//}
	}
	
	public void launch(){
		grounded = false;
		falling = false;
	}

	// Update is called once per frame
	void Update () {


		//Debug.Log ("keycode: "+Input.GetKeyDown(KeyCode.Space)+" grounded: "+grounded);
		//jumping = false;
		
		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			//Debug.Log ("jumped!!!");
			start = rb.position;
			if(Input.GetKey(KeyCode.DownArrow))
				rb.position+=new Vector2(0,-5.0f);
			else
				rb.velocity += new Vector2(0, jumpStrength);
			rotations = 0;
			//Debug.Log(rb.velocity);
			launch();
			//grounded = false;
			//jumping = true;
			
		}

		// variable to store the player's direction
		int leftOrRight;
		// gets the player's direction
		if (movement.dir == 1) {
			leftOrRight = -1;
		} else {
			leftOrRight = 1;
		}
		// if the player has fully rotated, resets the rotation
		if (rotations >= 24) {
			rotations = 0;
		}
		// rotates the player
		if (!grounded && (rotations % 2 == 0)) {
			rb.transform.Rotate (0, 0, (30*leftOrRight)); // rotates 60 degrees
			rotations++; // marks the rotation the player is on
		} else if (!grounded && (rotations % 2 == 1)) { // added to slow the rotation down, the rotation only happens on evens
			rotations++;
		} else if (rotations > 0) { // if the player has landed, reset their rotation
			rotations = 0;
			rb.transform.rotation = new Quaternion(0, 0, 0, 0);
		}

		if(rb.velocity.y < -maxFallSpeed){
			rb.velocity = new Vector2(rb.velocity.x, -maxFallSpeed);
		}
		
	}
}
