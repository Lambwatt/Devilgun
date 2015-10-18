using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform target;
	public float distance;
	//public float lift;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target)
			transform.position = new Vector3(target.position.x, target.position.y, distance);
	}

	public void setPlayer(Transform player){
		Debug.Log ("set player to "+player);
		target = player;
		//player
	}
}
