using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public LayerMask mask;
	public float speed = 10;
	public float damage = 15;
	public float skinWidth = 0.15f;

	Rigidbody2D rigidbody;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	public void SetVelocity(Vector2 dir)
	{
		rigidbody.velocity = dir.normalized * speed;
	}

	void Update()
	{
		float dist = Mathf.Abs( rigidbody.velocity.x) * Time.deltaTime + skinWidth;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, rigidbody.velocity.normalized, dist, mask);

		if (hit.collider != null) {
			hit.collider.GetComponent<PlayerHealth> ().TakeDamage (damage);
		}
	}
	

}
