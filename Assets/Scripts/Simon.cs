using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Simon : MonoBehaviour {
    public TextMeshPro billboard;
    public ControllerBoard controller;
    public LevelManager manager;

    int[] order = new int[] {1,3,4,4,0};
    string [] colors = new string[] {"red", "orange", "yellow", "green", "blue"};
    int orderiterator = -1;

	void Start () {
        controller = GetComponentInChildren<ControllerBoard>();
        manager = GetComponentInChildren<LevelManager>();
    }

    float timer = 1;
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 1f) {
            secondIterator();
            timer = 0;
        }
        if (status == 2 && controller.enabled_buttons[order[orderiterator]] == true && !hit) {
            hit = true;
            GlobalVariables.score += 100;
        }
    }

    int status = 0; // 0: starting 1:count 2:signal
    int period = 0; // starting:3 count:3 signal:1
    bool hit = false;
    void secondIterator() {
        if (status == 0) {
            billboard.SetText( "<b>Get Ready!");
            if (period == 1)
                billboard.SetText("");
            if (period == 3) {
                period = 0;
                status++;
            }
        }
        if ((status == 2 || orderiterator == 8) && period == 1) {
            period = 0;
            status--;
        }
        if (status == 1) {
            billboard.SetText("" +(3-period));
            if (period == 3) {
                period = 0;
                status++;
                orderiterator++;
                hit = false;
            }
        }
        if (orderiterator == order.Length - 1) {
            billboard.SetText("<b>Good Job!<br>:D");
            manager.nextLevel();
            if (period == 1) {
                billboard.SetText("");
                period = 0;
            }
            return;
        }

        if (status == 2) {
            billboard.SetText("<color="+colors[order[orderiterator]]+"><b>O");
        }
        period++;
    }

}
