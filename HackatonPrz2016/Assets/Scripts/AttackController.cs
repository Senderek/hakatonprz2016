using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {

	public Transform spawnPoint;
	public int startingStamina = 5;
	public float timeToStaminaRefill = 4;
	public float startingMana = 100;
	public float manaPerSecound = 9;
    [Header("Attacks:")]
    public GameObject ManaBar;
    [Header("Attacks:")]
	public LayerMask attackMask;
	public AttackInfo fastAttack;
	public AttackInfo strongAttack;
	public float attacksOffset;

	[Header("Special Attacks")]
	public SpecialAttackInfo fireball;

	SpriteRenderer renderer;
	PlayerMovement movement;

	Animator animator;

	string strFAttack;
	string strSAttack;
	string strDash;

	InputData inputData;

	int stamina;
	float staminaCounter;

	float mana;
	float manaCounter;

	Color originalColor;
	bool attackUsed;
	bool stopAttack;
	bool keypressed;

	[HideInInspector]
	public bool dooingAttack = false;

	void Awake()
	{
		renderer = GetComponent<SpriteRenderer> ();
		movement = GetComponent<PlayerMovement> ();
		animator = GetComponent<Animator> ();
		originalColor = renderer.color;
	}

	void Start()
	{
		strFAttack = movement.number == PlayerMovement.PlayerNumber.PLAYER1 ? GameSettings.Player1.keyBindings.fastAttack.ToLower() : GameSettings.Player2.keyBindings.fastAttack.ToLower();
		strSAttack = movement.number == PlayerMovement.PlayerNumber.PLAYER1 ? GameSettings.Player1.keyBindings.strongAttack.ToLower() : GameSettings.Player2.keyBindings.strongAttack.ToLower();
		strDash = movement.number == PlayerMovement.PlayerNumber.PLAYER1 ? GameSettings.Player1.keyBindings.dash.ToLower()  : GameSettings.Player2.keyBindings.dash.ToLower();
		stamina = startingStamina;
		mana = startingMana;
	}

	void Update()
	{
        ManaBar.GetComponent<UnityEngine.UI.Slider>().value = manaCounter;
		if (!dooingAttack && !movement.exhausted) {
			print (strFAttack);
			
			if (Input.GetKeyDown (strFAttack)) {
				inputData.fastAttack = true;
			}
			if (Input.GetKeyDown (strSAttack)) {
				inputData.strongAttack = true;
			}

			
			if (Input.GetKeyUp (strFAttack) && inputData.fastAttack) {
				fireball.used = false;
				inputData.fastAttack = false;
				StartCoroutine (StartAttack (fastAttack));
			}
			if (Input.GetKeyUp (strSAttack) && inputData.strongAttack) {
				fireball.used = false;
				inputData.strongAttack = false;
				StartCoroutine (StartAttack (strongAttack));
			}
			if (Input.GetKeyDown (strDash)) {
				//inputData.dashing = false;
				stamina--;
				movement.Dash ();
			}


				

			if (inputData.fastAttack && inputData.strongAttack) {
				inputData.Reset ();
				if (!attackUsed && mana >= fireball.manaCost) {						
					StartCoroutine(SpecialAttackCounter(fireball.cooldown));
					GameObject fb = (GameObject)Instantiate (fireball.gameObject, spawnPoint.position, transform.rotation);
					fb.GetComponent<FireBall> ().SetVelocity (movement.faceDirection);
					startingMana -= fireball.manaCost;
				}
			}
		}

		mana += manaPerSecound * Time.deltaTime;
		staminaCounter += Time.deltaTime;
		if (staminaCounter >= timeToStaminaRefill) {
			staminaCounter = 0;
			if (stamina < startingStamina)
				stamina++;
		}
		if (stamina <= 0) {
			movement.exhausted = true;
			stamina = startingStamina;
		}
	}

	public void GetFullStamina()
	{
		stamina = startingStamina;
	}
	public void GetFullMana()
	{
		mana = startingMana;
	}

	IEnumerator SpecialAttackCounter(float time)
	{
		stamina--;
		stopAttack = true;
		attackUsed = true;
		yield return new WaitForSeconds (time);
		attackUsed = false;
	}

	IEnumerator StartAttack(AttackInfo info)
	{
		animator.SetBool ("PlayerAttack", true);
		print (stamina);
		stamina--;
		dooingAttack = true;
		renderer.color = info.color;
		yield return new WaitForSeconds (info.duration);
		DoAttack (info);
		dooingAttack = false;
		renderer.color = originalColor;
		animator.SetBool ("PlayerAttack", false);


	}

	void DoAttack(AttackInfo attack)
	{
		Vector2 pointA = (new Vector2 (attacksOffset, -attack.width / 2) * movement.faceDirection.x + (Vector2)transform.position) ;
		Vector2 pointB = (new Vector2 (attacksOffset + attack.range, attack.width / 2) * movement.faceDirection.x + (Vector2)transform.position) ;
		Debug.DrawLine (pointA, pointB);
		Collider2D collider = Physics2D.OverlapArea (pointA,pointB, attackMask);
		if(collider != null){
			collider.GetComponent<PlayerHealth> ().TakeDamage (attack.damage);
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

	[System.Serializable]
	public struct SpecialAttackInfo
	{
		public string name;
		public GameObject gameObject;
		public float cooldown;
		public float manaCost;
		[HideInInspector]
		public bool used;
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

}
