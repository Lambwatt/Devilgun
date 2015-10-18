using UnityEngine;
using System.Collections;

public class ConfirmCollisionBehaviour : MonoBehaviour {

	// Use this for initialization
	private Collider2D myCollider;
	private Collider2D playerCollider;

	void Start(){
		playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
		myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("ignoring collisions? "+Physics2D.GetIgnoreCollision(myCollider, playerCollider));
	}
}
