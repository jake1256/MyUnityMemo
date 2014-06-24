using UnityEngine;
using System.Collections;

 /**
  * ステージを作成
  */
public class CreateStage : MonoBehaviour {

	private Connect connect;

	public GameObject cube;
	public GameObject wall;
	public int countW;
	public int countH;
	public int startX;
	public int startY;

	// Use this for initialization
	void Start () {
		connect = new Connect();

		int x;
		int y;
		int z;

		int value = 2;

		Transform transform = this.cube.transform;

		for(int i = 0 ; i < (countW * value) ; i++){
			x = startX + i;
			y = 1;
			for(int j = 0 ; j < (countH * value) ; j++){
				z = startY + j;
				if(i > 0 && i < (countW * value) - 1){
					if(j == 0 || j == (countH * value) - 1){
						Instantiate(this.wall , new Vector3(x , y , z) , transform.rotation);
					}
				}else{
					Instantiate(this.wall , new Vector3(x , y , z) , transform.rotation);
				}
			}
		}

		for(int i = 0 ; i < countW ; i++){
			x = startX + (i * 2);
			y = 1;
			for(int j = 0 ; j < countH ; j++){
				z = startY + (j * 2);

				Instantiate(this.cube , new Vector3(x , y , z) , transform.rotation);
			}

		}
	}

	// Update is called once per frame
	void Update () {

	}
}
