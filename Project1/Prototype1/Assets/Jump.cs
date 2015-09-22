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
	//private bool jumping = false;
	
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
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		falling = false;
		rotations = 8;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log ("keycode: "+Input.GetKeyDown(KeyCode.Space)+" grounded: "+grounded);
		//jumping = false;
		
		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			//Debug.Log ("jumped!!!");
			start = rb.position;
			rb.velocity += new Vector2(0, jumpStrength);
			rotations = 0;
			//Debug.Log(rb.velocity);
			launch();
			//grounded = false;
			//jumping = true;
			
		}
		// Causes the player to rotate during the jump
		if ((rb.position.y > ((.25 * (jumpStrength / 3)) + start.y)) && !falling && rotations < 1) {// first part of the jump
			rb.transform.Rotate (0, 0, 60); // rotates 60 degrees
			rotations++; // marks the rotation the player is on
			Debug.Log ("First Rotation" + rb.rotation);
		} else if ((rb.position.y > ((.50 * (jumpStrength / 3)) + start.y)) && !falling && rotations < 2) {// second part of the jump
			rb.transform.Rotate (0, 0, 60); // rotates 60 degrees
			rotations++; // marks the rotation the player is on
			Debug.Log ("Second Rotation" + rb.rotation);
		} else if ((rb.position.y > ((.85 * (jumpStrength / 3)) + start.y)) && !falling && rotations < 3) {// third part of the jump
			rb.transform.Rotate (0, 0, 60); // rotates 60 degrees
			rotations++; // marks the rotation the player is on
			Debug.Log ("Third Rotation" + rb.rotation);
		} else if (!falling && rotations < 4) {// checks to see if the player is falling yet
			if (rb.velocity.y < 0) {
				falling = true;
			}
		} else if ((rb.position.y < ((.85 * (jumpStrength / 3)) + start.y)) && falling && rotations < 4) {// fourth part of the jump
			rb.transform.Rotate (0, 0, 60); // rotates 60 degrees
			rotations++; // marks the rotation the player is on
			Debug.Log ("Fourth Rotation" + rb.rotation);
		} else if ((rb.position.y < ((.50 * (jumpStrength / 3)) + start.y)) && falling && rotations < 5) {// fifth part of the jump
			rb.transform.Rotate (0, 0, 60); // rotates 60 degrees
			rotations++; // marks the rotation the player is on
			Debug.Log ("Fifth Rotation" + rb.rotation);
		} else if ((rb.position.y < ((.25 * (jumpStrength / 3)) + start.y)) && falling && rotations < 6) {// sixth part of the jump
			rb.transform.Rotate (0, 0, 60); // rotates 60 degrees
			rotations++; // marks the rotation the player is on
			Debug.Log ("Sixth Rotation" + rb.rotation);
		} else if (grounded) {// if the player is done jumping, reset their rotation
			rb.transform.rotation = new Quaternion(0, 0, 0, 0);
		}
		
		if(rb.velocity.y < -maxFallSpeed){
			rb.velocity = new Vector2(rb.velocity.x, -maxFallSpeed);
		}
		
	}
}
