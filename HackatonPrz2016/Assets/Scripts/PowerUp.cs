using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour {

	public enum PowerUpType {HEALTH, MANA, STAMINA};
	public PowerUpType type;

	void OnColliderEnter(Collider other)
	{
		switch (type) {
		case PowerUpType.HEALTH: 
			break;
		}
	}
		
}
