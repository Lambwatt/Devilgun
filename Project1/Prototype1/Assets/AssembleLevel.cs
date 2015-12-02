using UnityEngine;
using System.Collections;

public class AssembleLevel : MonoBehaviour {


	public int width = 5;
	public int height = 4;
	public int roomsRemaining = 5;
	public GameObject startMarker;
	public GameObject endMarker;
	public RoomCollector rooms;
	//public GameObject[] rooms;//Find out how to force 16 if you settle on this method.
	public GameObject roomPrefab;

	// Use this for initialization
	void Start () {
		Blueprint specs = new Blueprint(width, height, roomsRemaining);
		for(int i = 0; i<specs.width; i++){
			for(int j = 0; j<specs.height; j++){
				string imagePath = rooms.getRoom (specs.map[i,j].getRoomCode());
				GameObject roomObject = Instantiate(roomPrefab, new Vector3(.32f*(float)i, .32f*(float)j), Quaternion.identity) as GameObject;
				Debug.Log (imagePath);
				Debug.Log (Resources.Load<Sprite>(imagePath) as Sprite);
				roomObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(imagePath, typeof(Sprite)) as Sprite;

				if(specs.map[i,j].isStart())
					Instantiate(startMarker, new Vector3(.32f*(float)i, .32f*(float)j), Quaternion.identity);

				if(specs.map[i,j].isBoss())
					Instantiate(endMarker, new Vector3(.32f*(float)i, .32f*(float)j), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
