using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScene : MonoBehaviour {
    public ControllerBoard controller;
    public LevelManager manager;
    public TextMeshPro leaderboard;

    bool istopscore = false;

	void Start () {
        controller = GetComponentInChildren<ControllerBoard>();
        manager = GetComponentInChildren<LevelManager>();
        GameObject[] destroy = GameObject.FindGameObjectsWithTag("music");
        foreach (GameObject obj in destroy)
            GameObject.Destroy(obj);
        leaderboard = GameObject.FindGameObjectWithTag("leaderboard").GetComponent<TextMeshPro>();
        string text = "";
        GlobalVariables.lastscore = GlobalVariables.score;
        if (GlobalVariables.score != 0) {
            GlobalVariables.scores.Add(GlobalVariables.score);
            GlobalVariables.names.Add("testname");
        }
        GlobalVariables.score = 0;
        if (GlobalVariables.lastscore > GlobalVariables.topscore)
        {
            istopscore = true;
            GlobalVariables.topscore = GlobalVariables.lastscore;
        }
        text += "<br><color=\"white\">Top Score:<br><size=10>" + GlobalVariables.topscore;
        text += "<br><br></size>Last Score:<br><color=\"green\"><size=10>" + GlobalVariables.lastscore;
        if (istopscore)
            text += "<br><color=\"black\"><b>NEW HIGH SCORE!</b></size>";

        leaderboard.SetText(text);

        DataController save = GameObject.FindGameObjectWithTag("save").GetComponent<DataController>();
        if (save)
            save.SaveGameData();
    }

	void Update () {
        if (controller.enabled_buttons[0])
        {
            controller.press_buttons[0] = true;
        }
        if (controller.enabled_buttons[4])
        {
            controller.press_buttons[4] = true;
        }
        Vector3 heightInc = new Vector3(0f, 0.001f, 0f);
        //Down
        if (controller.enabled_buttons[1] && !controller.enabled_buttons[3])
        {
            controller.gameObject.transform.position -= heightInc;
            GlobalVariables.controllerOffset -= heightInc;
            Debug.Log("Lowering: " + GlobalVariables.controllerOffset);
        }
        //UP
        if (controller.enabled_buttons[3] && !controller.enabled_buttons[1])
        {
            controller.gameObject.transform.position += heightInc;
            GlobalVariables.controllerOffset += heightInc;
            Debug.Log("Raising: " + GlobalVariables.controllerOffset);
        }

        if (controller.enabled_buttons[0] && controller.enabled_buttons[4])
        {
            manager.nextLevel();
        }

    }
}
