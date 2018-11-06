using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour {
    public ControllerBoard controller;
    public int score = GlobalVariables.score;
    public bool[] enabled_buttons;
    public string nextScene;
    public TextMeshPro scoreboard;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "start")
            scoreboard = GetComponentInChildren<TextMeshPro>();
        controller = GetComponentInChildren<ControllerBoard>();
        controller.gameObject.transform.position += GlobalVariables.controllerOffset;
        score = GlobalVariables.score;
    }

    void Update() {
        if (score < GlobalVariables.score) {
            score += 5;
        }
        if (score > GlobalVariables.score) {
            score--;
        }
        if (scoreboard)
            scoreboard.SetText(score.ToString());

    }

    bool loading = false;
    public void nextLevel()
    {
        if (!loading)
        {
            loading = true;
            //SceneManager.LoadScene(nextScene);
            StartCoroutine(LoadAsync());
        }

    }

    IEnumerator LoadAsync() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);
        while (!asyncLoad.isDone)
            yield return null;
    }

}
