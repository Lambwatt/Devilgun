using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public float x;
	public float y;

	void Start(){
	}

	public void spawn(){
		Debug.Log ("SPAWNING");
		Transform player = (Instantiate(Resources.Load("player"), new Vector3(transform.position.x+x,transform.position.y), Quaternion.identity) as GameObject).transform as Transform;
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowPlayer>().setPlayer(player);
	}
}
