using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class basketball_level : MonoBehaviour {
    public LevelManager manager;
    public float timeLimit = 10f;
    public TextMeshPro countdown;

	void Start () {
        manager = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<LevelManager>();
        countdown = GameObject.Find("Countdown").GetComponent<TextMeshPro>();
    }
    float timer = 0f;
    float second = 0;
    void Update () {
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            manager.nextLevel();
        }
        if (timer > second)
        {
            second++;
            countdown.SetText("<b>" + (timeLimit - second + 1) + "<br>seconds");
        }

	}
}
