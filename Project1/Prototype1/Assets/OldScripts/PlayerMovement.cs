using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1;

	private Vector3 horizontalDirection;
	private Rigidbody move;


	// Use this for initialization
	void Start () {
		move = GetComponent<Rigidbody> ();

		horizontalDirection = Vector3.right;

	}
	
	// Update is called once per frame
	void Update () {
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");

		move.velocity = new Vector3((h * speed), 0, 0);




	}
}
