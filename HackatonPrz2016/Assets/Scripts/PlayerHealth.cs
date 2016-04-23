using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour {
    public GameObject HealthBar;
    public GameObject koniec;
    public GameObject winner;

    public float startingHealth = 100;
	public GameObject deathParticle;

	PlayerMovement mov;
	float health;

	void Start()
	{
		mov = GetComponent<PlayerMovement> ();
		health = startingHealth;
        

	}

	void Update()
	{

        //Debug.Log("1:"+health.ToString());
        //Debug.Log("2: "+HealthBar.GetComponent<UnityEngine.UI.Slider>().value);
        if (health > 0 || HealthBar.GetComponent<UnityEngine.UI.Slider>().value == 0)
            HealthBar.GetComponent<UnityEngine.UI.Slider>().value = health / 100;
        else HealthBar.GetComponent<UnityEngine.UI.Slider>().value = 0;
        //Debug.Log("3:"+HealthBar.GetComponent<UnityEngine.UI.Slider>().value);
        

        try {
		} catch {
		}
	}

	public void RefillHealth()
	{
		health = startingHealth;
	}

	public void TakeDamage(float dmg)
	{
		GetComponent<Animator> ().SetTrigger ("PlayerHit");
		health -= mov.exhausted ? dmg * 2 : dmg;
		if (health <= 0) {
            HealthBar.GetComponent<UnityEngine.UI.Slider>().value = 0;
            GameObject.FindObjectOfType<CameraController> ().StopUpdating ();

            StartCoroutine(dontHaveFuckingIdeaWhatItIS());
            Instantiate (deathParticle);
            mov.enabled = false;
            GetComponent<AttackController>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
			//DestroyImmediate (gameObject);
            
        }
	}
    IEnumerator dontHaveFuckingIdeaWhatItIS()
    {
        yield return new WaitForSeconds(2);
            koniec.SetActive(true);
            winner.GetComponent<UnityEngine.UI.Text>().text = "PLAYER " + gameObject.name.ToUpper() + " WON. CONGRATULATIONS";
        
    }

}
