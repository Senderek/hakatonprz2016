using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour {
    public GameObject HealthBar;
    
    
    public float startingHealth = 100;

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
        if(health>0 || HealthBar.GetComponent<UnityEngine.UI.Slider>().value ==0)
        HealthBar.GetComponent<UnityEngine.UI.Slider>().value=health/100;
        //Debug.Log("3:"+HealthBar.GetComponent<UnityEngine.UI.Slider>().value);
        try {
		} catch {
		}
	}

	public void TakeDamage(float dmg)
	{
		GetComponent<Animator> ().SetTrigger ("PlayerHit");
		health -= mov.exhausted ? dmg * 2 : dmg;
		if (health <= 0) {
            HealthBar.GetComponent<UnityEngine.UI.Slider>().value = 0;
            GameObject.FindObjectOfType<CameraController> ().StopUpdating ();
			DestroyImmediate (gameObject);
		}
	}


}
