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
        CONTROLSMENU1,
        CONTROLSMENU2,

    };
  //  [SerializeField]
    public EMenuState currentState;
    //main menu
    [Header("Containers:")]
    public GameObject MainmenuC;
    public GameObject CreditsC;
    public GameObject OptionsC;
    public GameObject Controls1C;
    public GameObject Controls2C;
    [Header("Buttons from playmode:")]
    public GameObject RDefault1Button;
    public GameObject RDefault2Button;
    public GameObject ReturnFromControls1;
    public GameObject ReturnFromControls2;
    public GameObject ReturnButton;
    public GameObject PlayButton;




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
        //Input.
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
    public void OnReturnToMainMenuButtonPressed()
    {
        this.currentState = EMenuState.MAINMENU;
        OnMenuChangeState();
    }
    public void OnPlayModeButtonPressed()
    {
        this.currentState = EMenuState.PLAYMENU;
        OnMenuChangeState();
    }
    public void OnControls1ButtonPressed()
    {
        this.currentState = EMenuState.CONTROLSMENU1;
        OnMenuChangeState();
    }
    public void OnControls2ButtonPressed()
    {
        this.currentState = EMenuState.CONTROLSMENU2;
        OnMenuChangeState();
    }
    public void setinactive()
    {
        MainmenuC.SetActive(false);
        CreditsC.SetActive(false);
        OptionsC.SetActive(false);
        Controls1C.SetActive(false);
        Controls2C.SetActive(false);
        RDefault1Button.SetActive(false);
        RDefault2Button.SetActive(false);
        ReturnButton.SetActive(false);
        PlayButton.SetActive(false);
        ReturnFromControls1.SetActive(false);
        ReturnFromControls2.SetActive(false);
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
                    setinactive();
                    MainmenuC.SetActive(true);
                    

                    break;
                }
            case EMenuState.CREDITSMENU:
                {
                    setinactive();
                    CreditsC.SetActive(true);
                    break;
                }
            case EMenuState.PLAYMENU:
                {
                    setinactive();
                    OptionsC.SetActive(true);
                    ReturnButton.SetActive(true);
                    PlayButton.SetActive(true);
                    ReturnFromControls1.SetActive(false);
                    ReturnFromControls2.SetActive(false);
                    RDefault1Button.SetActive(false);
                    RDefault2Button.SetActive(false);
                    break;
                }
            case EMenuState.CONTROLSMENU1:
                setinactive();
                OptionsC.SetActive(true);
                ReturnFromControls1.SetActive(true);
                RDefault1Button.SetActive(true);
                Controls1C.SetActive(true);

                break;
            case EMenuState.CONTROLSMENU2:
                setinactive();
                OptionsC.SetActive(true);
                Controls2C.SetActive(true);
                ReturnFromControls2.SetActive(true); 
                RDefault2Button.SetActive(true);
                break;
            default:
                Debug.Log("switch,default");
                break;
        }
    }
   
}
