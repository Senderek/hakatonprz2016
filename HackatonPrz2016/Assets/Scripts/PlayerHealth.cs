using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float startingHealth = 100;
	public int startingStamina = 4;

	float health;
	float stamina;

	void Start()
	{
		health = startingHealth;
		stamina = startingStamina;
	}

	void Update()
	{
		try {
		} catch {
		}
	}

	public void TakeDamage(float dmg)
	{
		health -= dmg;
		if (health <= 0) {
			GameObject.FindObjectOfType<CameraController> ().StopUpdating ();
			DestroyImmediate (gameObject);
		}
	}


}
