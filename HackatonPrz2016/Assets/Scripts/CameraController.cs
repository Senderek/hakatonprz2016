using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {
    [Header("Nameplates:")]
    public GameObject PlayerName1;
    public GameObject PlayerName2;
    public float clampPosition;
	public List<Transform> playersList = new List<Transform>();

	bool stopUpdate;

	void Start () {
        if (GameSettings.Player1.name == ""|| GameSettings.Player1.name == null)
            PlayerName1.GetComponent<UnityEngine.UI.Text>().text = "PLAYER1";
        else
        PlayerName1.GetComponent<UnityEngine.UI.Text>().text = GameSettings.Player1.name.ToString().ToUpper();
        if (GameSettings.Player2.name == "")
            PlayerName2.GetComponent<UnityEngine.UI.Text>().text = "PLAYER2"; else
        PlayerName2.GetComponent<UnityEngine.UI.Text>().text = GameSettings.Player2.name.ToString().ToUpper();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player")){
			playersList.Add (g.transform);
			//print ("Find");
		}
	
	}

	void Update () {
		if(!stopUpdate)
			UpdateCameraPosition ();

		Vector3 newPos = new Vector3 (Mathf.Clamp (transform.position.x, -clampPosition, clampPosition), transform.position.y, transform.position.z);
		transform.position = newPos;
	}

	public void StopUpdating()
	{
		stopUpdate = true;
	}

	void UpdateCameraPosition()
	{
		Transform mostLeftPlayer = playersList[0];
		Transform mostRightPlayer = playersList [0];

		foreach (Transform t in playersList) {
			if(t.gameObject != null){
				if (t.position.x > mostRightPlayer.position.x) {
					mostRightPlayer = t;
				}

				if (t.position.x < mostLeftPlayer.position.x) {
					mostLeftPlayer = t;
				}
			}
		}

		//print ("Left:" + mostLeftPlayer.name);
		//print ("Right:" + mostRightPlayer.name);
			
		Vector3 pos = (mostLeftPlayer.position + mostRightPlayer.position) / 2;
		transform.position = new Vector3 (pos.x, transform.position.y, transform.position.z);
	}
}
