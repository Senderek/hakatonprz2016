using UnityEngine;
using System.Collections;

public class PowerUpsSpawner : MonoBehaviour {

	public GameObject health;
	public GameObject stamina;
	public GameObject mana;

	public float verticalClamp = 6;
	public float horizontalClamp = 1.4f;

	public float minWaitTime = 4;
	public float maxWaitTime = 7;

	void Start()
	{
		StartCoroutine (SpawningThoseLittleShits ());
	}

	IEnumerator SpawningThoseLittleShits()
	{
		while (true) {
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

			Vector2 pos = new Vector2 (Random.Range (-verticalClamp, verticalClamp), 
				              Random.Range (-horizontalClamp, horizontalClamp));

			int random = Random.Range (0, 3);

			switch (random) {
			case 0:
				Instantiate (health, pos, Quaternion.identity);
				break;
			case 1:
				Instantiate (health, pos, Quaternion.identity);
				break;
			case 2:
				Instantiate (health, pos, Quaternion.identity);
				break;
			}
		}
	}
}
