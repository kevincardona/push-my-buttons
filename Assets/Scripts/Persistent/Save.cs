using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save  {
    public List<int> scores = new List<int>();
    public List<string> names = new List<string>();

    public int highscore = 0;

    public Save(List<int> scores, List<string> names, int highscore) {
        this.scores = scores;
        this.names = names;
        this.highscore = highscore;
    }
    public Save() {

    }
}
