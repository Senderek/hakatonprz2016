using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeybindsController : Singleton<KeybindsController>
{

    public enum EControlsState
    {
        MOVEUP,
        MOVEDOWN,
        MOVERIGHT,
        MOVELEFT,
        FASTATTACK,
        SLOWATTACK,
        DASH,
        nothing,
    };
    public EControlsState currentState;
    [Header("Buttons:")]
    public GameObject moveup;
    public GameObject movedown;
    public GameObject moveleft;
    public GameObject moveright;
    public GameObject fastattack;
    public GameObject slowattack;
    public GameObject dash;

    [Header("Texts:")]
    public GameObject moveuptext;
    public GameObject movedowntext;
    public GameObject movelefttext;
    public GameObject moverighttext;
    public GameObject fastattacktext;
    public GameObject slowattacktext;
    public GameObject dashtext;
   
    bool button;
    Dictionary<EControlsState, GameObject> asd = new Dictionary<EControlsState, GameObject>();
    string keycode = KeyCode.N.ToString();
    public static KeybindsController Instance
    {
        
        get
        {
            return ((KeybindsController)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }
    public void detectPressedKeyOrButton()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("KeyCode M: ");
        }
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {            
            if (Input.GetKeyDown(kcode))
            {
                keycode = kcode.ToString();
                Debug.Log("KeyCode down: " + kcode);
            }
        }
    }
    public void OnMoveup()
    {
        button = true;
        this.currentState = EControlsState.MOVEUP;
        //OnControlerChangeState();
    }
    public void OnMoveDown()
    {
        button = true;
        this.currentState = EControlsState.MOVEDOWN;
        //OnControlerChangeState();

    }
    public void OnMoveright()
    {
        button = true;
        this.currentState = EControlsState.MOVERIGHT;
        //OnControlerChangeState();

    }
    public void OnMoveLeft()
    {
        button = true;
        this.currentState = EControlsState.MOVELEFT;
        //OnControlerChangeState();

    }
    public void OnFastAttack()
    {
        button = true;
        this.currentState = EControlsState.FASTATTACK;
        //OnControlerChangeState();

    }
    public void OnSlowAttack()
    {
        button = true;
        this.currentState = EControlsState.SLOWATTACK;
        //OnControlerChangeState();

    }
    public void OnDash()
    {
        button = true;
        this.currentState = EControlsState.DASH;
        //OnControlerChangeState();

    }
    public void OnControlerChangeState()
    {
        switch (currentState)
        {
            case EControlsState.nothing:
                Debug.Log("nothing");
                break;

            case EControlsState.MOVEUP:
                moveuptext.GetComponent<UnityEngine.UI.Text>().text = keycode.ToString();
               // gameSettings.keymoveup(keycode);
                button = false;
                break;
            case EControlsState.MOVEDOWN:
                movedowntext.GetComponent<UnityEngine.UI.Text>().text = keycode.ToString();
                break;
            case EControlsState.MOVERIGHT:
                

                moverighttext.GetComponent<UnityEngine.UI.Text>().text = keycode.ToString();
                break;
            case EControlsState.MOVELEFT:
                movelefttext.GetComponent<UnityEngine.UI.Text>().text = keycode;
                break;
            case EControlsState.FASTATTACK:
                fastattacktext.GetComponent<UnityEngine.UI.Text>().text = keycode;
                break;
            case EControlsState.SLOWATTACK:
                slowattacktext.GetComponent<UnityEngine.UI.Text>().text = keycode;
                break;
            case EControlsState.DASH:
                dashtext.GetComponent<UnityEngine.UI.Text>().text = keycode;
                break;
            
        }
    }
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        //Debug.Log(keycode);
        if (button==true&&!Input.GetMouseButton(0)&& Input.anyKeyDown)
        {
              
            Debug.Log("mouse");
            detectPressedKeyOrButton();
            
            //if (!Input.GetMouseButton(0))
            //Debug.Log(Input.inputString);
            //keycode = Input.inputString;
            //Debug.Log("Napisalo: "+keycode);
            OnControlerChangeState();
        }
        
        
	}
}
