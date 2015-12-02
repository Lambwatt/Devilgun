using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class Room{

	public int [,] tiles;
	public int width;
	public int height;

	public Room(int width, int height){
		this.width = width;
		this.height = height;
		tiles = new int[width, height];
	}
}

public class RoomImporter{

	Room room;

	void Start(){
		room = loadRoom("Assets/TestLevel/DemoLevel.oel");
	}

	public Room loadRoom(string path){

		StreamReader reader = new StreamReader(path);
		string contents = reader.ReadToEnd();

		XmlDocument doc = new XmlDocument();
		doc.LoadXml(contents);

		Room room = new Room(32, 32);

		char[] delimiters = {',', '\n'};
		XmlNode node = doc.SelectSingleNode("level");

		XmlNode n = node.SelectSingleNode("Tiles");

		string tileString = node.SelectSingleNode("Tiles").InnerText;
		string[] tiles = tileString.Split(delimiters);

		for(int i = 0; i<room.width; i++){
			for(int j = 0; j<room.height; j++){
				room.tiles[i, j] = int.Parse(tiles[i*room.width+j]);
			}
		}

		return room;
//		var stream = new FileStream(path, FileMode.Open);
//		var reader = XmlReader.Create(stream);
//
//		var level = reader.(Level);
//		stream.Close();
//		return level;
	}
}

