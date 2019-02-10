using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static string[] padName = new string[2];
    private string currentPadName;

    private bool isDS4;
    private bool isXbox;
    private bool isKeyboard;

    static Dictionary<string, KeyCode> keyMapping;

    static string[] keyMaps = new string[8]
        {
            "Jump",
            "Fire",
            "Inventory",
            "Select",
            "Start",
            "ForwardInv", //avanti nella selezione oggetti
            "BackInv", //indietro nella selezione oggetti
            "Use"
        };

    void keyboardKeys()
    {
        if (isKeyboard)
            {
            KeyCode[] Keyboard = new KeyCode[8]
                {
            KeyCode.Space,
            KeyCode.LeftControl,
            KeyCode.Tab,
            KeyCode.Return,
            KeyCode.Escape,
            KeyCode.E,
            KeyCode.Q,
            KeyCode.LeftShift
                };
        }
    }
    void ds4Keys()
    {
        if (isDS4)
        {
            KeyCode[] DS4 = new KeyCode[8]
              {
            KeyCode.Joystick1Button1,
            KeyCode.Joystick1Button0,
            KeyCode.Joystick1Button8,
            KeyCode.Joystick1Button3,
            KeyCode.Joystick1Button9,
            KeyCode.Joystick1Button5,
            KeyCode.Joystick1Button4,
            KeyCode.Joystick1Button2
              };
        }
    }
    void xboxKeys()
    {
        if (isXbox)
        {
            KeyCode[] Xbox = new KeyCode[8]
                {
            KeyCode.Joystick1Button0,
            KeyCode.Joystick1Button2,
            KeyCode.Joystick1Button6,
            KeyCode.Joystick1Button3,
            KeyCode.Joystick1Button7,
            KeyCode.Joystick1Button5,
            KeyCode.Joystick1Button4,
            KeyCode.Joystick1Button1
                };
        }
    }

    // Use this for initialization
    void Start () {

        padName[0] = "Wireless Controller";
        padName[1] = "Xbox 360 Controller";
        
    }

    void Awake()
    {
        currentPadName = Input.GetJoystickNames()[0];
        
    }

    // Update is called once per frame
    void Update() {

        Debug.Log("CONTROLLER NAME: " + currentPadName);
        keysAssign();

        if (isDS4)
        {            
            isXbox = false;
        }
        else if (isXbox)
        {
            isDS4 = false;
        }

        keyboardKeys();
        ds4Keys();
        xboxKeys();
    }

    void keysAssign()
    {
        if (currentPadName == padName[0])
        {
            isDS4 = true;
        }
        else if (currentPadName == padName[1])
        {
            isXbox = true;
        }
        else if (currentPadName == "")
        {
            isKeyboard = true;
        }

    }

    void InitDictionary()
    {
        keyMapping = new Dictionary<string, KeyCode>();
        for (int i = 0; i < keyMaps.Length; ++i)
        {
            //keyMapping.Add(keyMaps[i], Keyboard[i]);
        }
    }

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keyMapping[keyMap]);
    }

}

