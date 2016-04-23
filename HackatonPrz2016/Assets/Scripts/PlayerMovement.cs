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

	void Awake()
	{
		faceDirection = Vector2.right;
		renderer = GetComponent<SpriteRenderer> ();
		rigidbody = GetComponent<Rigidbody2D> ();
		attackController = GetComponent<AttackController> ();
		originalColor = renderer.color;
	}

	void Update()
	{
		if (attackController.dooingAttack) {
			velocity = Vector2.zero;
		}
		else if(!dashing && !exhausted)
		{
			string strVert = number == PlayerNumber.PLAYER1 ? "VerticalP1" : "VerticalP2";
			string strHor = number == PlayerNumber.PLAYER1 ? "HorizontalP1" : "HorizontalP2";

			float vertical = Input.GetAxisRaw (strVert);
			float horizontal = Input.GetAxisRaw (strHor);

			if (horizontal != 0)
				faceDirection = new Vector2 (horizontal, 0);

			if (horizontal == -1)
				transform.rotation = Quaternion.Euler (0, 180, 0);
			else if (horizontal == 1)
				transform.rotation = Quaternion.identity;

			velocity = new Vector3 (horizontal, vertical,0).normalized * moveSpeed;

		}

		if (exhausted) {
			exhaustCounter += Time.deltaTime;
			if (exhaustCounter >= exhaustTime) {
				exhaustCounter = 0;
				exhausted = false;
			}
		}
	}

	public void Dash()
	{
		StartCoroutine (DashCor ());
	}

	IEnumerator DashCor()
	{
		velocity = velocity.normalized * dashSpeed;
		dashing = true;
		yield return new WaitForSeconds (dashTime);
		dashing = false;
	}


	void FixedUpdate()
	{
		rigidbody.MovePosition (transform.position + velocity * Time.fixedDeltaTime);
	}

}
