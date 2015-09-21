using UnityEngine;
using System.Collections;

public class generateFloor : MonoBehaviour {

	public int numTiles;

	// Use this for initialization
	void Start () {
		for(int i = 0; i<numTiles;i++){
			Instantiate(Resources.Load("block"), new Vector3(i*10, -20),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
}
