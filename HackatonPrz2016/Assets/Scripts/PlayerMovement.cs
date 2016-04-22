using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public enum PlayerNumber {PLAYER1, PLAYER2};

	public float moveSpeed = 5;
	public PlayerNumber number;

	void Update()
	{
		string strVert = number == PlayerNumber.PLAYER1 ? "VerticalP1" : "VerticalP2";
		string strHor = number == PlayerNumber.PLAYER1 ? "HorizontalP1" : "HorizontalP2";

		float vertical = Input.GetAxisRaw (strVert);
		float horizontal = Input.GetAxisRaw (strHor);

		transform.Translate (new Vector2 (horizontal, vertical) * moveSpeed *  Time.deltaTime);
	}
}
