using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public float x;
	public float y;

	void Start(){
	}

	public void spawn(){
		Debug.Log ("SPAWNING");
		Transform player = (Instantiate(Resources.Load("player"), new Vector3(transform.position.x+x+9/2,transform.position.y+y-9), Quaternion.identity) as GameObject).transform as Transform;
		Debug.Log ("spawning at "+(transform.position.x+x+9/2)+", "+(transform.position.y+9));
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowPlayer>().setPlayer(player);
	}
}
