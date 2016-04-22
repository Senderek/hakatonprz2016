using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{


    public enum EMenuState
    {
        MAINMENU,
        PLAYMENU,
        CREDITSMENU,
        EXITMENU,

    };
    [SerializeField]
    public EMenuState currentState;
    //main menu
    [Header("Main menu buttons: ")]
    public GameObject StartGameButton;
    public GameObject CreditsButton;
    public GameObject ExitButton;

    /* public static MenuController Instance
     {
         get
         {
             return ((MenuController)mInstance);
         }
         set
         {
             mInstance = value;
         }
     }*/


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
