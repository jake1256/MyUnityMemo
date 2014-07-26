using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {

	// public field
	public float rightX;
	public float rightY;
	public float width;
	public float height;


	private static MiniMap instance;
	private UtilDraw2D draw2D;
	private bool isDraw;

	private ArrayList enemyList;
	private GameObject player;

	private float[] enemyX;
	private float[] enemyY;


	void Awake()
	{
		if(instance == null){
			instance = this;
			isDraw = false;
			draw2D = new UtilDraw2D();
		}else{
			Destroy( this );
		}
	}

	public static MiniMap Instance {
		get { return MiniMap.instance; }
	}

	public void setEnemyList(ArrayList enemyList){
		this.enemyList 	= enemyList;
		int count = this.enemyList.Count;
		Debug.Log ("setEnemyList count == " + count);
		enemyX = new float[count];
		enemyY = new float[count];

		checkInit();
	}

	public void setPlayer(GameObject player){
		Debug.Log("setPlayer");
		this.player 	= player;
		checkInit();
	}

	private void checkInit(){
		Debug.Log ("checkInit : " + this.player + " | " + this.enemyList);
		if(this.player != null && this.enemyList != null){
			Debug.Log ("isDraw true!! ");
			isDraw = true;
		}
	}

	void OnPostRender() {
		if(isDraw){
			calcMiniMap();

			// 描画開始.
			draw2D.Begin();
			{
				drawBg();

				float dd = 3.0f;
				// draw enemy
				int count = this.enemyList.Count;
				for(int i = 0 ; i < count ; i++){
					if(enemyX[i] != 0 && enemyY[i] != 0){
						drawEnemyCircle(enemyX[i] * dd , enemyY[i] * dd , dd);
					}
				}

				// draw player
				drawPlayerCircle(dd);
				
			}
			// 描画終了.
			draw2D.End();
		}
	}

	private void calcMiniMap(){
		float x = player.transform.position.x;
		float y = player.transform.position.z;
		int count = this.enemyList.Count;
		for(int i = 0 ; i < count ; i++){
			GameObject enemy = this.enemyList[i] as GameObject;
			if(enemy != null){
				float ex = enemy.transform.position.x;
				float ey = enemy.transform.position.z;
				
				enemyX[i] = x - ex;
				enemyY[i] = y - ey;
			}else{
				enemyX[i] = 0;
				enemyY[i] = 0;
			}

		}
	}

	// draw rect
	private void drawBg(){
		draw2D.SetLineWidth(1.0f);
		draw2D.SetLineDot(0.0f);

		float v0X = Screen.width  - rightX;
		float v0Y = Screen.height - rightY;
		float v1X = v0X - width;
		float v1Y = v0Y - height;

		Vector3 v0 = new Vector3(v0X , v0Y);
		Vector3 v1 = new Vector3(v1X , v1Y);              
		draw2D.DrawRectangleFill(v0, v1, new Color(0.0f, 0.2f, 0.0f));
		draw2D.DrawRectangle(v0, v1, Color.red);
	}

	private void drawPlayerCircle(float r){
		float cX = Screen.width  - rightX - (width / 2);
		float cY = Screen.height - rightY - (height / 2);

		Vector3 center = new Vector3(cX , cY , 0.0f);
		draw2D.DrawCircleFill(center, r, new Color(0.0f, 0.0f, 0.8f));
		draw2D.DrawCircle(center, r, Color.black);
	}

	// draw circle
	private void drawEnemyCircle(float x , float y , float r){
		float cX = Screen.width  - rightX - (width / 2);
		float cY = Screen.height - rightY - (height / 2);


		draw2D.SetLineWidth(1.0f);
		draw2D.SetLineDot(0.0f);
		
		Vector3 center = new Vector3(cX + x, cY + y, 0.0f);
		draw2D.DrawCircleFill(center, r, new Color(0.4f, 0.0f, 0.0f));
		draw2D.DrawCircle(center, r, Color.black);
	}
}
