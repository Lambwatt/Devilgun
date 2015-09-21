using UnityEngine;
using System.Collections;

public class moveLeftOrRight : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		rb.velocity = new Vector2(0, rb.velocity.y);

		if(Input.GetKey(KeyCode.RightArrow)){
			rb.velocity += new Vector2(moveSpeed, 0);
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			rb.velocity += new Vector2(-moveSpeed, 0);
		}

	}
}
