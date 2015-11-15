using UnityEngine;
using System.Collections;

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
		for(int i = 0; i<room.width; i++){
			for(int j = 0; j<room.height; j++){
				Debug.Log ("Test result: "+(room.tiles[i,j]>=0));
				if(room.tiles[i,j]>=0){
					Debug.Log (tiles[room.tiles[i,j]]);
					Instantiate(tiles[room.tiles[i,j]], new Vector3(.32f*(float)i, .32f*(float)j), Quaternion.identity);
				}
			}
		}
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}

