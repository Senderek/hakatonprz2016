using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

	public List<Transform> playersList = new List<Transform>();

	void Start () {

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player")){
			playersList.Add (g.transform);
			//print ("Find");
		}
	
	}

	void Update () {
		UpdateCameraPosition ();
	}

	void UpdateCameraPosition()
	{
		Transform mostLeftPlayer = playersList[0];
		Transform mostRightPlayer = playersList [0];

		foreach (Transform t in playersList) {
			if (t.position.x > mostRightPlayer.position.x) {
				mostRightPlayer = t;
			}

			if (t.position.x < mostLeftPlayer.position.x) {
				mostLeftPlayer = t;
			}
		}

		//print ("Left:" + mostLeftPlayer.name);
		//print ("Right:" + mostRightPlayer.name);
			
		Vector3 pos = (mostLeftPlayer.position + mostRightPlayer.position) / 2;
		transform.position = new Vector3 (pos.x, transform.position.y, transform.position.z);
	}
}
