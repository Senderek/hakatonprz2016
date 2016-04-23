using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public enum PlayerNumber {PLAYER1, PLAYER2};

	public PlayerNumber number;
	[Header("Movement:")]
	public float moveSpeed = 5;
	public float dashSpeed = 30;
	public float dashTime = 0.4f;
	[Header("Attacks:")]
	public LayerMask attackMask;
	public AttackInfo fastAttack;

	public AttackInfo strongAttack;

	public float attacksOffset;

	[Header("Special Attacks")]
	public GameObject fireball;

	Rigidbody2D rigidbody;
	Vector3 velocity;
	Vector2 faceDirection;

	float timer = 0;

	InputData inData;

	SpriteRenderer renderer;
	Color originalColor;

	void Awake()
	{
		inData.Reset ();
		renderer = GetComponent<SpriteRenderer> ();
		rigidbody = GetComponent<Rigidbody2D> ();
		originalColor = renderer.color;
	}

	void Update()
	{
		if(!inData.IsBusy())
		{
			string strVert = number == PlayerNumber.PLAYER1 ? "VerticalP1" : "VerticalP2";
			string strHor = number == PlayerNumber.PLAYER1 ? "HorizontalP1" : "HorizontalP2";

			float vertical = Input.GetAxisRaw (strVert);
			float horizontal = Input.GetAxisRaw (strHor);

			if(horizontal != 0)
				faceDirection = new Vector2 (horizontal, 0);

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

		if (inData.fastAttack) {
			timer += Time.deltaTime;
			if (timer >= fastAttack.duration) {
				timer = 0;
				inData.fastAttack = false;
				renderer.color = originalColor;
				DoAttack (fastAttack);
			}
		}

		if (inData.strongAttack) {
			timer += Time.deltaTime;
			if (timer >= strongAttack.duration) {
				timer = 0;
				inData.strongAttack = false;
				renderer.color = originalColor;
			}
		}

		rigidbody.MovePosition (transform.position + velocity * Time.deltaTime);
	}

	IEnumerator StartAttack(AttackInfo info)
	{
		velocity = Vector2.zero;
		renderer.color = info.color;
		yield return new WaitForSeconds (info.duration);
		DoAttack (info);

	}
		
		
	void DoAttack(AttackInfo attack)
	{
		Vector2 pointA = (new Vector2 (attacksOffset, -attack.width / 2) * faceDirection.x + (Vector2)transform.position) ;
		Vector2 pointB = (new Vector2 (attacksOffset + attack.range, attack.width / 2) * faceDirection.x + (Vector2)transform.position) ;
		Debug.DrawLine (pointA, pointB);
		Collider2D collider = Physics2D.OverlapArea (pointA,pointB, attackMask);
		if(collider != null){
			collider.GetComponent<PlayerHealth> ().TakeDamage (attack.damage);
		}
	}

	void InputAttackHandler()
	{
		string strFAttack = number == PlayerNumber.PLAYER1 ? "fAttackP1" : "fAttackP2";
		string strSAttack = number == PlayerNumber.PLAYER1 ? "sAttackP1" : "sAttackP2";
		string strDash = number == PlayerNumber.PLAYER1 ? "DashP1" : "DashP2";

		if (Input.GetButtonDown (strFAttack)) {
			inData.fastAttack = true;
			StartCoroutine (StartAttack (fastAttack));
		}
		if (Input.GetButtonDown (strSAttack)) {
			inData.strongAttack = true;
			StartCoroutine (StartAttack (strongAttack));
		}
		if (Input.GetButtonDown (strDash)) {
			inData.dashing = true;
			velocity = velocity.normalized * dashSpeed;
		}


		if (Input.GetButton (strFAttack) && Input.GetButton (strSAttack)) {
			GameObject fb = (GameObject) Instantiate (fireball, (Vector2)transform.position + faceDirection , Quaternion.identity);
			fb.GetComponent<FireBall> ().SetVelocity (faceDirection);
		}
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

		public bool IsBusy()
		{
			return (fastAttack || strongAttack || dashing);
		}
	}

	[System.Serializable]
	public struct AttackInfo
	{
		public Color color;
		public float duration;
		public float damage;
		public float range;
		public float width;
	}
}
