using UnityEngine;
using System.Collections;

public class CreateManager : MonoBehaviour {

	public GameObject parentObject;
	public GameObject piecePrefab;
	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		create ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void create(){
		int initX = -2;
		int initY = -3;

		ArrayList pieceList = new ArrayList ();

		for (int i = 0; i < 5; i++) {
			for(int j = 0 ; j < 7 ; j++){
				GameObject obj = createPiece(i , j , initX + i , initY + j);
				pieceList.Add(obj);
			}
		}
		gameManager.init (pieceList);
	}

	public GameObject createPiece(int i , int j , int x , int y){


		int idx = Random.Range (1 , 5);
		GameObject obj = Instantiate(piecePrefab) as GameObject;
		SpriteRenderer sr = obj.GetComponent("SpriteRenderer") as SpriteRenderer;
		sr.sprite = Resources.Load<Sprite> ("piece/piece_0" + idx);
		obj.name = "piece_" + i + "_" + j;

		Piece p = obj.GetComponent<Piece> ();
		p.ImgIdx = idx;
		p.ArrIdxI = i;
		p.ArrIdxJ = j;

		obj.transform.position = new Vector3(x , y , 0);
		obj.transform.parent = parentObject.transform;

		return obj;
	}

}
