using UnityEngine;
using System.Collections;

public enum RoomType{ Normal, Start, Boss, Evt}

public class RoomSpec{

	private int doors = 0;
	private RoomType typ = RoomType.Normal;

	public RoomSpec(){
		Debug.Log("Ran Default Constructor");
	}

	public void addTopDoor(){
		doors |= 8;
	}

	public void addLeftDoor(){
		doors |= 4;
	}

	public void addBottomDoor(){
		doors |= 2;
	}

	public void addRightDoor(){
		doors |= 1;
	}

	public int getRoomCode(){
		return doors;
	}

	public bool isStart(){
		return typ == RoomType.Start;
	}

	public bool isBoss(){
		return typ == RoomType.Boss;
	}

	public bool isEmpty(){
		return doors == 0;
	}

	public void markRoomAsStart(){
		typ = RoomType.Start;
	}

	public void markRoomAsBoss(){
		typ = RoomType.Boss;
	}
}

public class Blueprint {

	public int width = 5;
	public int height = 4;
	public int roomsRemaining = 5;
	public RoomSpec[,] map;
	private int x;
	private int y;

	public Blueprint(int width, int height, int roomsRemaining){
		this.width = width;
		this.height = height;
		this.roomsRemaining = roomsRemaining;

		map = new RoomSpec[width,height];

		for(int i = 0; i<width; i++){
			for(int j = 0; j<height; j++){
				map[i,j] = new RoomSpec();
			}
		}

		x = Mathf.FloorToInt(Random.value*width);
		y = Mathf.FloorToInt(Random.value*height);
		map[x,y].markRoomAsStart();

		tracePath();

		map[x,y].markRoomAsBoss();

	}

	private void tracePath(){
		int i = 0;
		do{
			i = Mathf.FloorToInt(Random.value*4);
			switch(i){
			case 0:
				moveRight();
				break;
			case 1:
				moveDown();
				break;
			case 2:
				moveLeft();
				break;
			case 3:
				moveUp();
				break;
			default:
				Debug.Log ("Warning. Used default case!");
				break;
			}
			
		}while(roomsRemaining>0);
	}



	private bool moveRight(){
		if(x+1 < width  && !map[x+1, y].isStart()){

			if(map[x+1, y].isEmpty())
				roomsRemaining--;

			map[x, y].addRightDoor();
			x++;
			map[x, y].addLeftDoor();
			return true;
		}else{
			return false;
		}
	}

	private bool moveDown(){
		if(y > 0  && !map[x, y-1].isStart()){
			if(map[x, y-1].isEmpty())
				roomsRemaining--;
			
			map[x, y].addBottomDoor();
			y--;
			map[x, y].addTopDoor();
			return true;
		}else{
			return false;
		}
	}

	private bool moveLeft(){
		if(x > 0  && !map[x-1, y].isStart()){
			
			if(map[x-1, y].isEmpty())
				roomsRemaining--;
			
			map[x, y].addLeftDoor();
			x--;
			map[x, y].addRightDoor();
			return true;
		}else{
			return false;
		}
	}

	private bool moveUp(){
		if(y+1 < height  && !map[x, y+1].isStart()){
			if(map[x, y+1].isEmpty())
				roomsRemaining--;

			map[x, y].addTopDoor();
			y++;
			map[x, y].addBottomDoor();
			return true;
		}else{
			return false;
		}
	}


}
