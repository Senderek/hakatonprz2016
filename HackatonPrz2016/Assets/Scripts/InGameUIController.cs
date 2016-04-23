using UnityEngine;
using System.Collections;

public class InGameUIController : MonoBehaviour {
    
        [Header("Nameplates:")]
    public GameObject PlayerName1;
    public GameObject PlayerName2;
    void Awake() {
        if (GameSettings.Player1.name == "")//|| GameSettings.Player1.name == null)
            PlayerName1.GetComponent<UnityEngine.UI.Text>().text = "DWARF1";
        else
            PlayerName1.GetComponent<UnityEngine.UI.Text>().text = GameSettings.Player1.name.ToString().ToUpper();
        if (GameSettings.Player2.name == "")
            PlayerName2.GetComponent<UnityEngine.UI.Text>().text = "DWARF2";
        else
            PlayerName2.GetComponent<UnityEngine.UI.Text>().text = GameSettings.Player2.name.ToString().ToUpper();
    }
}
