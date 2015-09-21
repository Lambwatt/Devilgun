using UnityEngine;
using System.Collections;

public class DetectGround : MonoBehaviour {

	private Jump jump;
	
	// Use this for initialization
	void Start () {
		jump = transform.parent.GetComponent<Jump>();
	}

	void OnTriggerStay2D(){
		//Debug.Log ("hit?");
		jump.land();
	}

	void OnTriggerEnter2D(){
		//Debug.Log ("hit?");
		jump.land();
	}

//	void OnTriggerExit2D(){
//		Debug.Log ("hit?");
//		jump.launch();
//	}
}
