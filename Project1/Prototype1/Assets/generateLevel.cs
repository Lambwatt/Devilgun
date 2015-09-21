using UnityEngine;
using System.Collections;

public class generateLevel : MonoBehaviour {

	int[,] level = new int[4,4];
	int x;
	int y = 0;

	string[] rooms = new string[5]{"Room0", "Room1", "Room2a", "Room3", "Room2b"};

	// Use this for initialization
	void Start () {
		x = (int)Mathf.Floor(Random.value*4);
		level[x,y] = 1;
		int start_x = x;
		int last_x = x;
		int last_y = y;

		Debug.Log ("starting at ["+x+","+y+"]");
		int n;
		bool valid;
		while(y < 4){
			do{
				n = (int)Mathf.Floor(Random.value*5);
				valid = false;
				if(n == 0 || n == 1){
					if(x-1>=0 && level[x-1,y] == 0){

						Debug.Log ("left");
						Debug.Log("nextSlot = "+level[x-1,y]);
						x-=1;

						valid = true;
					}
				}else if(n == 2 || n == 3){
					if(x+1<4 && level[x+1,y] == 0){
						Debug.Log ("right");
						Debug.Log("nextSlot = "+level[x+1,y]);
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
				float fl = Mathf.Floor(Random.value*3)+1;
				level[last_x, last_y] = (int)fl;
				Debug.Log(fl+":"+level[last_x, last_y]);
				last_x = x;

			}else{
				level[last_x, last_y] = 4;
				last_y = y;
			}

		}


		for(int w = 0; w < 4; w++){
			for(int h = 0; h < 4; h++){
				Debug.Log ("converting room type "+level[w,h]+"int "+rooms[level[w,h]]);
				Instantiate(Resources.Load(rooms[level[w,h]]), new Vector3(w*100, h*-80), Quaternion.identity);
			}
		}

		//Instantiate(Resources.Load("player"))
	}
}
