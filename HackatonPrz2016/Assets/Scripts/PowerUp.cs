using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour {

	public enum PowerUpType {HEALTH, MANA, STAMINA};
	public PowerUpType type;

	void OnTriggerEnter2D(Collider2D other)
	{
		switch (type) {
		case PowerUpType.HEALTH:
			other.GetComponent<PlayerHealth> ().RefillHealth ();
			break;
		case PowerUpType.MANA:
			other.GetComponent<AttackController> ().RefilMana ();
			break;
		case PowerUpType.STAMINA:
			other.GetComponent<AttackController> ().RefilStamina ();
			break;
		}

		Destroy (gameObject);
	}
		
}
