using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float jumpStrength;
	public float maxFallSpeed;

	private Rigidbody2D rb;

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
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	
	}

	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("keycode: "+Input.GetKeyDown(KeyCode.Space)+" grounded: "+grounded);
		//jumping = false;

		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			//Debug.Log ("jumped!!!");
			rb.velocity += new Vector2(0, jumpStrength);
			//Debug.Log(rb.velocity);
			launch();
			//grounded = false;
			//jumping = true;
		}

		if(rb.velocity.y < -maxFallSpeed){
			rb.velocity = new Vector2(rb.velocity.x, -maxFallSpeed);
		}

	}
}
