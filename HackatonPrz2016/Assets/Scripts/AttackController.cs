using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour {

	void Start()
	{
		StartCoroutine (test());
	}


	IEnumerator test()
	{
		print ("Start");
		yield return new WaitForSeconds (5);
		print ("Stop");
	}

}
