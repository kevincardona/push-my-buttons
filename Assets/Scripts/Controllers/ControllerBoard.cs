using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBoard : MonoBehaviour {
    public GameObject[] buttonPrefabs;
    GameObject[] buttons;
    public Button1[] button_script;
    public bool[] enabled_buttons;
    public bool[] press_buttons;
    void Start()
    {
        button_script = new Button1[buttonPrefabs.Length];
        buttons = new GameObject[buttonPrefabs.Length];
        enabled_buttons = new bool[buttonPrefabs.Length];
        press_buttons = new bool[buttonPrefabs.Length];

        for (int i = 0; i < buttonPrefabs.Length; i++)
        {
            buttons[i] = buttonPrefabs[i].transform.GetChild(1).gameObject;
            button_script[i] = buttons[i].GetComponent<Button1>();
            enabled_buttons[i] = buttonPrefabs[i].transform.GetChild(1).GetComponent<Button1>().isPressed;
            press_buttons[i] = false;
        }
    }

    void Update () {
        for (int i = 0; i < buttonPrefabs.Length; i++)
        {
            buttons[i] = buttonPrefabs[i].transform.GetChild(1).gameObject;
            if (press_buttons[i] == true)
                buttonPrefabs[i].transform.GetChild(1).GetComponent<Button1>().forcePress = true;
            else
                buttonPrefabs[i].transform.GetChild(1).GetComponent<Button1>().forcePress = false;
            enabled_buttons[i] = buttonPrefabs[i].transform.GetChild(1).GetComponent<Button1>().isPressed;
        }
    }
}
