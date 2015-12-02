using UnityEngine;
using System.Collections;
using System;

public class RoomAssembler : MonoBehaviour {

	public GameObject[] tiles; 
	// Use this for initialization
	void Start () {

		RoomImporter importer = new RoomImporter();

		Room room = importer.loadRoom("Assets/TestLevel/DemoLevel.oel");
		assembleRoom(room);
		Debug.Log ("Assembled?");
	}

	void assembleRoom(Room room){
		string input = "";
		for(int i = 0; i<room.width; i++){
			for(int j = 0; j<room.height; j++){
				input+=room.tiles[j,i]+",";
				if(room.tiles[j,i]>=0){
					Instantiate(tiles[room.tiles[j,i]], new Vector3(.32f*(float)i, .32f*(float)(room.height-j)), Quaternion.identity);
				}
			}
			input+="\n";
		}
		Debug.Log (input);
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}

