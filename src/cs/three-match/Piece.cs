using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour{
	private int pieceId;
	private int imgIdx;
	private int arrIdxI; // i
	private int arrIdxJ; // j
	private bool isDel;

	public int PieceId {
		get {
			return pieceId;
		}
		set {
			pieceId = value;
		}
	}

	public int ImgIdx {
		get {
			return imgIdx;
		}
		set {
			imgIdx = value;
		}
	}

	public int ArrIdxI {
		get {
			return arrIdxI;
		}
		set {
			arrIdxI = value;
		}
	}

	public int ArrIdxJ {
		get {
			return arrIdxJ;
		}
		set {
			arrIdxJ = value;
		}
	}

	public bool IsDel {
		get {
			return isDel;
		}
		set {
			isDel = value;
		}
	}
}
