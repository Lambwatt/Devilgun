using UnityEngine;
using System.Collections;

public class generateLevel : MonoBehaviour {

	int[,] level = new int[4,4];
	Transform[,] roomObjects = new Transform[4,4];
	int x;
	int y = 0;

	string[] rooms = new string[5]{"Room0", "Room1", "Room2b", "Room3", "Room2a"};

	// Use this for initialization
	void Start () {
		x = (int)Mathf.Floor(Random.value*4);
		//level[x,y] = 1;
		int start_x = x;
		int last_x = x;
		int last_y = y;

		//Debug.Log ("starting at ["+x+","+y+"]");
		int n;
		bool valid;
		bool wentDown = false;;
		while(y < 4){
			do{
				n = (int)Mathf.Floor(Random.value*5);
				valid = false;
				if(n == 0 || n == 1){
					if(x-1>=0 && level[x-1,y] == 0){

						Debug.Log ("left");
						//Debug.Log("nextSlot = "+level[x-1,y]);
						x-=1;

						valid = true;
					}
				}else if(n == 2 || n == 3){
					if(x+1<4 && level[x+1,y] == 0){
						Debug.Log ("right");
						//Debug.Log("nextSlot = "+level[x+1,y]);
						x+=1;

						valid = true;
					}
				}else{
					if(y+1<5){
						y+=1;
						Debug.Log ("down");
						valid = true;
					}
				}
			}while(!valid);

			if(n<4){
				float fl;
				if(wentDown){
					fl = Mathf.Floor(Random.value*2)+2;//if went down, must have enterance in the top in current tile
					Debug.Log ("caught down. set room to "+fl);
					wentDown = false;
				}
				else fl = Mathf.Floor(Random.value*3)+1;
				level[last_x, last_y] = (int)fl;
				//Debug.Log(fl+":"+level[last_x, last_y]);
				last_x = x;

			}else{
				if(wentDown)
					level[last_x, last_y] = 2;
				else
					level[last_x, last_y] = 4;
				wentDown = true;
				last_y = y;
			}

		}

		int numNonZeroRooms = 0;
		for(int i = 0; i<4; i++){
			//Debug.Log ("level["+i+", 0] = "+level[i, 0])
			if(level[i, 0]!=0)
				numNonZeroRooms++;
		}
		
		Debug.Log("sum = "+numNonZeroRooms);
		if(numNonZeroRooms == 1) level[start_x, 0] = 2;
		else level[start_x, 0] = 1;


		for(int w = 0; w < 4; w++){
			for(int h = 0; h < 4; h++){
				//Debug.Log ("converting room type "+level[w,h]+"int "+rooms[level[w,h]]);
				//int num = ;
				//Debug.Log ("num = "+num);
				roomObjects[w,h] = (Instantiate(Resources.Load(rooms[level[w,h]]), new Vector3(w*100, h*-80), Quaternion.identity)as GameObject).transform as Transform;
				//Debug.Log ("room "+w+", "+h+": "+roomObjects[w,h]);
			}
		}
		//Debug.Log(roomObjects[start_x, 0]);
		SpawnPlayer spawner = roomObjects[start_x, 0].GetComponent<SpawnPlayer>();
		//Debug.Log (spawner);
		spawner.spawn();

		for( int w = -1; w<=40; w++){
			Instantiate(Resources.Load("block"), new Vector3(w*10, 10), Quaternion.identity);
		}

		for( int w = -1; w<=40; w++){
			Instantiate(Resources.Load("block"), new Vector3(w*10, -80*4), Quaternion.identity);
		}

		for( int h = 0; h<32; h++){
			Instantiate(Resources.Load("block"), new Vector3(-10, h*-10), Quaternion.identity);
		}

		for( int h = 0; h<32; h++){
			Instantiate(Resources.Load("block"), new Vector3(400, h*-10), Quaternion.identity);
		}
	}
}
