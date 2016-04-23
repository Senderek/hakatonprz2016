using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
    [Header("Keybinds:")]
    public GameObject moveuptext;
    public GameObject movedowntext;
    public GameObject movelefttext;
    public GameObject moverighttext;
    public GameObject fastattacktext;
    public GameObject slowattacktext;
    public GameObject dashtext;

    public GameObject moveuptext2;
    public GameObject movedowntext2;
    public GameObject movelefttext2;
    public GameObject moverighttext2;
    public GameObject fastattacktext2;
    public GameObject slowattacktext2;
    public GameObject dashtext2;
    [Header("Player names:")]
    public GameObject name1;
    public GameObject name2;
    // [Header("Player colors:")]
    
    Color color1;
    Color color2;



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


        GameSettings.Player1.keyBindings.up = moveuptext.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.keyBindings.down = movedowntext.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.keyBindings.right = moverighttext.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.keyBindings.left=movelefttext.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.keyBindings.fastAttack=fastattacktext.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.keyBindings.strongAttack = slowattacktext.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.keyBindings.dash = dashtext.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.name = name1.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player1.color = color1;

        GameSettings.Player2.keyBindings.up = moveuptext2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.keyBindings.down = movedowntext2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.keyBindings.right = moverighttext2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.keyBindings.left = movelefttext2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.keyBindings.fastAttack = fastattacktext2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.keyBindings.strongAttack = slowattacktext2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.keyBindings.dash = dashtext2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.name = name2.GetComponent<UnityEngine.UI.Text>().text.ToString();
        GameSettings.Player2.color = color2;


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
        if (this.currentState == EMenuState.CONTROLSMENU1)
            this.currentState = EMenuState.PLAYMENU;
        else 
        this.currentState = EMenuState.CONTROLSMENU1;
        OnMenuChangeState();
    }
    public void OnControls2ButtonPressed()
    {
        if (this.currentState == EMenuState.CONTROLSMENU2)
        this.currentState = EMenuState.PLAYMENU;
        else
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
    public void RestoreDefaults2()
    {
        moveuptext.GetComponent<UnityEngine.UI.Text>().text = "UpArrow";
        movedowntext.GetComponent<UnityEngine.UI.Text>().text = "DownArrow";
        movelefttext.GetComponent<UnityEngine.UI.Text>().text = "LeftArrow";
        moverighttext.GetComponent<UnityEngine.UI.Text>().text = "RightArrow";
        fastattacktext.GetComponent<UnityEngine.UI.Text>().text = "m";
        slowattacktext.GetComponent<UnityEngine.UI.Text>().text = ",";
        dashtext.GetComponent<UnityEngine.UI.Text>().text = ".";

    }
    public void RestoreDefaults1()
    {
        moveuptext2.GetComponent<UnityEngine.UI.Text>().text = "w";
        movedowntext2.GetComponent<UnityEngine.UI.Text>().text = "s";
        movelefttext2.GetComponent<UnityEngine.UI.Text>().text = "a";
        moverighttext2.GetComponent<UnityEngine.UI.Text>().text = "d";
        fastattacktext2.GetComponent<UnityEngine.UI.Text>().text = "f";
        slowattacktext2.GetComponent<UnityEngine.UI.Text>().text = "g";
        dashtext2.GetComponent<UnityEngine.UI.Text>().text = "h";

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
                RDefault2Button.SetActive(true);
                Controls1C.SetActive(true);

                break;
            case EMenuState.CONTROLSMENU2:
                setinactive();
                OptionsC.SetActive(true);
                Controls2C.SetActive(true);
                ReturnFromControls2.SetActive(true); 
                RDefault1Button.SetActive(true);
                break;
            default:
                Debug.Log("switch,default");
                break;
            
        }
    }
   void Awake()
    {
        this.currentState = EMenuState.MAINMENU;
        OnMenuChangeState();
        RestoreDefaults1();
        RestoreDefaults2();
    }
}
