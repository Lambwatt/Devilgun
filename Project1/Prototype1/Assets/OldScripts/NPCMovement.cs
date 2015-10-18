using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class NPCMovement : MonoBehaviour {
	
	public float speed = 5f;
	public float delay = 5f;
	public type movementType;
	public enum type { Wander, SetTasks, RandomTasks, Break }

	private CharacterController controller;
	private Vector3 targetRotation;
	private float direction;
	private List<Transform> waypoints = new List<Transform>();
	private int currentWp;
	private int lastWp;
	private bool arrived = false;
	private float arrivalTime;
	private Vector3 target;
	private bool hold = true;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();


		foreach (Transform child in transform)
			if(child.tag == "Waypoint")
				waypoints.Add (child);
		
		foreach(Transform waypoint in waypoints)
			waypoint.parent = null;

		target = waypoints [currentWp].position - transform.position;
		Debug.Log (waypoints.Count);

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.TransformDirection (1, 0, 0);
		Debug.Log (currentWp);

		if (movementType == type.Wander && hold) {
			InvokeRepeating ("NpcWander", 0f, 2f);
			hold = false;
		} else if (movementType == type.Wander) {
			controller.SimpleMove (forward);
		}else if (movementType != type.Wander) {
			CancelInvoke();
			WalkToWaypoints ();
			hold = true;
		}

	}


	void FixedUpdate(){
		//Debug.Log (Time.time);
	}

	//Makes the npc walk to the waypoints
	void WalkToWaypoints(){

		if (waypoints.Count > 0) {
			if (!arrived) {
				if (Vector3.Distance (transform.position, waypoints [currentWp].position) < 0.3f) {
					arrivalTime = Time.time;
					arrived = true;
				} 
				//Moves to the waypoint
				controller.SimpleMove (target);
				//Debug.Log (target);
			} else {
				if (Time.time > arrivalTime + delay) {
					NextWP ();
					arrived = false;
					transform.rotation = Quaternion.LookRotation(waypoints[currentWp].position - transform.position);  //Changes the direction the character faces
				}
			}
		}
	}
	//Picks a random direction and turns the character to that direction
	void NpcWander(){
		direction = Random.Range (0, 360);
		transform.eulerAngles = new Vector3 (0, direction, 0);
	}
/*
	public bool StartAndStop(bool stop){
		stillWalking = stop;
		return stillWalking;
	}
*/
	//Picks the next waypoint dependant on movementType
	void NextWP(){
		if (movementType == type.SetTasks) {
			currentWp = (currentWp == waypoints.Count - 1) ? 0 : currentWp += 1;
		} else if (movementType == type.RandomTasks) {
			currentWp = Random.Range (0, waypoints.Count - 1);
			if(lastWp == currentWp){
				currentWp += 1;
			}
			lastWp = currentWp;
		}
		target = waypoints [currentWp].position - transform.position;
	}

	//draw gizmo spheres for waypoints
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		foreach (Transform child in transform)
		{
			if(child.tag == "Waypoint")
				Gizmos.DrawSphere(child.position, .3f);
		}
	}

}
