using UnityEngine;
using System.Collections;

public class platformColliderController : MonoBehaviour {

	Collider2D platformCollider;

	// Use this for initialization
	void Start () {
		platformCollider = transform.parent.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	void OnTriggerEnter2D(Collider2D col){
//		Debug.Log (col.gameObject.tag);
//		if(!col.gameObject.CompareTag("Player"))
//			return;
//
//
//		Debug.Log (platformCollider.gameObject.name);
//	
//		Debug.Log ("should ignore collision");
//		bool ignore = false;
//		if(!isAbove(col)){
//			Debug.Log ("object is below");
//			ignore = true;
//		}
//		if(!isMovingDown(col)){
//			Debug.Log ("object is not moving down");
//			ignore = true;
//		}
//
//		if(goingDown(col)){
//			Debug.Log ("player is tryingto go down");
//			ignore = true;
//		}
////		Debug.Log ("ignore = "+ignore);
////		Debug.Log()
//		Physics2D.IgnoreCollision(platformCollider, col, true);
//		//Debug.Log ("ignoring collisions? "+Physics2D.GetIgnoreCollision(platformCollider, col));
	}



	void OnTriggerExit2D(Collider2D col){
		Debug.Log ("should not ignore collision");
		Physics2D.IgnoreCollision(platformCollider, col, false);
	}


	bool isAbove(Collider2D col){
		return col.bounds.center.y - col.bounds.extents.y > platformCollider.bounds.center.y + platformCollider.bounds.extents.y;
	}

//	bool isMovingDown(Collider2D col){
//
//		return col.gameObject.GetComponent<Jump>().isMovingDown();
//	}
//
//	bool goingDown(Collider2D col){
//
//		return col.gameObject.GetComponent<Jump>().isGoingDown();
//	}
}
