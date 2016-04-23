using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour {
    
        [Header("Nameplates:")]
    public GameObject PlayerName1;
    public GameObject PlayerName2;
    [Header("Congratz:")]
    public GameObject WhoWon;
    public GameObject Finish;
    void Awake() {
        Finish.SetActive(false);
        if (GameSettings.Player1.name == "")//|| GameSettings.Player1.name == null)
            PlayerName1.GetComponent<UnityEngine.UI.Text>().text = "DWARF1";
        else
            PlayerName1.GetComponent<UnityEngine.UI.Text>().text = GameSettings.Player1.name.ToString().ToUpper();
        if (GameSettings.Player2.name == "")
            PlayerName2.GetComponent<UnityEngine.UI.Text>().text = "DWARF2";
        else
            PlayerName2.GetComponent<UnityEngine.UI.Text>().text = GameSettings.Player2.name.ToString().ToUpper();
    }
    public void OnExitPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainmenu");
        
    }
    void Start()
    {
       StartCoroutine(dontHaveFuckingIdeaWhatItIS());
    }

    IEnumerator dontHaveFuckingIdeaWhatItIS()
    {
        while (true)
        { 
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            WhoWon.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(1);
        }
    }
    void Update()
    {
      
        
    }
}
