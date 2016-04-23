using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public enum PlayerNumber {PLAYER1, PLAYER2};

	public PlayerNumber number;
	[Header("Movement:")]
	public float moveSpeed = 5;
	public float dashSpeed = 30;
	public float dashTime = 0.4f;

	Rigidbody2D rigidbody;
	[HideInInspector]
	public Vector3 velocity;
	[HideInInspector]
	public Vector2 faceDirection;
	[HideInInspector]
	public bool exhausted;
	public float exhaustTime = 3;
	float exhaustCounter;

	float timer = 0;

	SpriteRenderer renderer;
	Color originalColor;

	AttackController attackController;
	bool dashing = false;

	TrailRenderer trail;
	Animator anim;

	void Awake()
	{
		faceDirection = Vector2.right;
		renderer = GetComponent<SpriteRenderer> ();
		rigidbody = GetComponent<Rigidbody2D> ();
		attackController = GetComponent<AttackController> ();
		originalColor = renderer.color;
		trail = GetComponent<TrailRenderer> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		if (attackController.dooingAttack) {
			velocity = Vector2.zero;
		}
		else if(!dashing && !exhausted)
		{
			//string strVert = number == PlayerNumber.PLAYER1 ? "VerticalP1" : "VerticalP2";
			//string strHor = number == PlayerNumber.PLAYER1 ? "HorizontalP1" : "HorizontalP2";
			//GameSettings.Player1.keyBindings.CheckArrows();
			//GameSettings.Player2.keyBindings.CheckArrows ();

			string strUp = number == PlayerNumber.PLAYER1 ? GameSettings.Player1.keyBindings.up.ToLower() : GameSettings.Player2.keyBindings.up.ToLower();
			string strDown = number == PlayerNumber.PLAYER1 ? GameSettings.Player1.keyBindings.down.ToLower() : GameSettings.Player2.keyBindings.down.ToLower();
			string strLeft = number == PlayerNumber.PLAYER1 ? GameSettings.Player1.keyBindings.left.ToLower() : GameSettings.Player2.keyBindings.left.ToLower();
			string strRight = number == PlayerNumber.PLAYER1 ? GameSettings.Player1.keyBindings.right.ToLower() : GameSettings.Player2.keyBindings.right.ToLower();

			string[] arrows = { "LeftArrow", "RightArrow", "UpArrow", "DownArrow" };
			string[] dirs = { "left", "right", "up", "down" };

			for(int i =0; i < arrows.GetLength(0); i++)
			{
				if (GameSettings.Player1.keyBindings.up == arrows [i]) {
					GameSettings.Player1.keyBindings.up = dirs [i];
				}
				if (GameSettings.Player1.keyBindings.down == arrows [i]) {
					GameSettings.Player1.keyBindings.down = dirs [i];
				}
				if (GameSettings.Player1.keyBindings.left == arrows [i]) {
					GameSettings.Player1.keyBindings.left = dirs [i];
				}
				if (GameSettings.Player1.keyBindings.right == arrows [i]) {
					GameSettings.Player1.keyBindings.right = dirs [i];
				}
				if (GameSettings.Player2.keyBindings.up == arrows [i]) {
					GameSettings.Player2.keyBindings.up = dirs [i];
				}
				if (GameSettings.Player2.keyBindings.down == arrows [i]) {
					GameSettings.Player2.keyBindings.down = dirs [i];
				}
				if (GameSettings.Player2.keyBindings.left == arrows [i]) {
					GameSettings.Player2.keyBindings.left = dirs [i];
				}
				if (GameSettings.Player2.keyBindings.right == arrows [i]) {
					GameSettings.Player2.keyBindings.right = dirs [i];
				}
			}


			float vertical;// = Input.GetAxisRaw (strVert);
			float horizontal;// = Input.GetAxisRaw (strHor);

			if (Input.GetKey (strLeft))
				horizontal = -1;
			else if (Input.GetKey (strRight))
				horizontal = 1;
			else
				horizontal = 0;

			if (Input.GetKey (strUp))
				vertical = 1;
			else if (Input.GetKey (strDown))
				vertical = -1;
			else
				vertical = 0;

			if (horizontal != 0)
				faceDirection = new Vector2 (horizontal, 0);

			if (horizontal == -1)
				transform.rotation = Quaternion.Euler (0, 180, 0);
			else if (horizontal == 1)
				transform.rotation = Quaternion.identity;

			velocity = new Vector3 (horizontal, vertical,0).normalized * moveSpeed;

		}

		if (exhausted) {
			velocity = Vector2.zero;
			anim.SetBool ("PlayerExhausted", true);
			renderer.color = Color.gray;
			exhaustCounter += Time.deltaTime;
			if (exhaustCounter >= exhaustTime) {
				exhaustCounter = 0;
				exhausted = false;
				anim.SetBool ("PlayerExhausted", false);
				renderer.color = originalColor;
			}
		}
	}

	public void Dash()
	{
		StartCoroutine (DashCor ());
	}

	IEnumerator DashCor()
	{
		trail.enabled = true;
		velocity = velocity.normalized * dashSpeed;
		dashing = true;
		yield return new WaitForSeconds (dashTime);
		dashing = false;
		trail.enabled = false;
	}


	void FixedUpdate()
	{
		rigidbody.MovePosition (transform.position + velocity * Time.fixedDeltaTime);
	}

}
