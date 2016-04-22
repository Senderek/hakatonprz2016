using UnityEngine;
using System.Collections;


public class MenuController : Singleton<MenuController>
{


    public enum EMenuState
    {
        MAINMENU,
        PLAYMENU,
        CREDITSMENU,
        EXITMENU,

    };
  //  [SerializeField]
    public EMenuState currentState;
    //main menu
    [Header("Containers:")]
    public GameObject MainmenuC;
    public GameObject CreditsC;


    [Header("Main menu buttons: ")]
    public GameObject StartGameButton;
    public GameObject CreditsButton;
    public GameObject ExitButton;

     public static MenuController Instance
     {
         get
         {
             return ((MenuController)mInstance);
         }
         set
         {
             mInstance = value;
         }
     }



    void Start()
    {
        OnMenuChangeState();
    }

    public void OnCreditsButtonPressed()
    {
        this.currentState = EMenuState.CREDITSMENU;
        OnMenuChangeState();

    }
    public void OnExitButtonPressed()
    {
        this.currentState = EMenuState.EXITMENU;
        OnMenuChangeState();
    }
    public void OnPlayButtonPressed()
    {
        this.currentState = EMenuState.PLAYMENU;
        OnMenuChangeState();
    }
    public void OnReturnToMainMenuButtonPressed()
    {
        this.currentState = EMenuState.MAINMENU;
        OnMenuChangeState();
    }
    void OnMenuChangeState()
    {
        switch (currentState)
        {
            case EMenuState.EXITMENU:
                {
                    Application.Quit();
                    break;
                }
            case EMenuState.MAINMENU:
                {
                    MainmenuC.SetActive(true);
                    CreditsC.SetActive(false);

                    break;
                }
            case EMenuState.CREDITSMENU:
                {
                    MainmenuC.SetActive(false);
                    CreditsC.SetActive(true);
                    break;
                }
            default:
                Debug.Log("switch,default");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
