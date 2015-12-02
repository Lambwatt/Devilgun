using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

public class RoomCollector : MonoBehaviour {
	
	public string pathFromResourcesToFolders;
	public string[] folders; //Need to force 16 probably
	private List<List<string>> rooms;
	
	// Use this for initialization - Consider changing so this isn't a behaviuour
	void Start(){
		if(hasNoRooms()){
			collectRooms();
		}
	}

	private void collectRooms () {

		rooms = new List<List<string>>(); 
		//Debug.Log (System.IO.Directory.GetCurrentDirectory());
		foreach(string s in folders){
			List<string> list = new List<string>();
			foreach (string file in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory()+"/Assets/Resources"+pathFromResourcesToFolders+"/"+s)){ 
				if(file.EndsWith("png")){

					//Debug.Log (file.Substring((System.IO.Directory.GetCurrentDirectory()+"/Assets/Resources"+pathFromResourcesToFolders+"/").Length));
					list.Add(file.Substring((System.IO.Directory.GetCurrentDirectory()+"/Assets/Resources/").Length));
				}
			}
			rooms.Add(list);
		}
	}
	
	public string getRoom(int index){
		if(hasNoRooms())
			collectRooms();

		if(index<rooms.Count){
			int selection = Mathf.FloorToInt(Random.value*rooms[index].Count);
			return (rooms[index][selection]).Substring(0, rooms[index][selection].Length-4);
		}else{
			return null;
		}
	}

	private bool hasNoRooms(){
		return rooms == null || rooms.Count == 0;
	}
}









