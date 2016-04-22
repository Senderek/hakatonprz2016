using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public enum PlayerNumber {PLAYER1, PLAYER2};

	public float moveSpeed = 5;
	public float dashSpeed = 30;
	public float dashTime = 0.4f;
	public PlayerNumber number;

	Rigidbody2D rigidbody;
	Vector3 velocity;

	float timer = 0;

	InputData inData;

	void Awake()
	{
		inData.Reset ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if(!inData.dashing)
		{
			string strVert = number == PlayerNumber.PLAYER1 ? "VerticalP1" : "VerticalP2";
			string strHor = number == PlayerNumber.PLAYER1 ? "HorizontalP1" : "HorizontalP2";

			float vertical = Input.GetAxisRaw (strVert);
			float horizontal = Input.GetAxisRaw (strHor);

			velocity = new Vector3 (horizontal, vertical,0).normalized * moveSpeed;
			//transform.Translate (new Vector2 (horizontal, vertical) * moveSpeed *  Time.deltaTime);
		}
		InputAttackHandler ();

		if (inData.dashing) {
			timer += Time.deltaTime;
			if (timer >= dashTime) {
				timer = 0;
				inData.dashing = false;
			}
		}

		rigidbody.MovePosition (transform.position + velocity * Time.deltaTime);
	}

	void InputAttackHandler()
	{
		string strFAttack = number == PlayerNumber.PLAYER1 ? "fAttackP1" : "fAttackP2";
		string strSAttack = number == PlayerNumber.PLAYER1 ? "sAttackP1" : "sAttackP2";
		string strDash = number == PlayerNumber.PLAYER1 ? "DashP1" : "DashP2";
		if (Input.GetButtonDown (strFAttack)) {
			inData.fastAttack = true;
			
		}
		if (Input.GetButtonDown (strSAttack)) {
		}
		if (Input.GetButtonDown (strDash)) {
			print ("dashing out");
			Dash ();
		}
	}

	void Dash()
	{
		inData.dashing = true;
		velocity = velocity.normalized * dashSpeed;
	}

	void FixedUpdate()
	{
		rigidbody.MovePosition (transform.position + velocity * Time.fixedDeltaTime);
	}

	struct InputData
	{
		public bool fastAttack, strongAttack, dashing;

		public void Reset()
		{
			fastAttack = strongAttack = dashing = false;
		}
	}
}
