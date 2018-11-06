using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    private string gameDataFileName = "data.json";

	void Start () {
		DontDestroyOnLoad(gameObject);
        LoadGameData();
        SceneManager.LoadScene("start");
	}

	void Update () {

	}

    public void SaveGameData() {
        // 1
        List<int>tscores = GlobalVariables.scores;
        List<string>tnames = GlobalVariables.names;
        int thigh = GlobalVariables.topscore;
      Save save = new Save(tscores, tnames, thigh);

      // 2
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
      bf.Serialize(file, save);
      file.Close();
      Debug.Log("Game Saved");
    }

    public void LoadGameData()
    {
      if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
      {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();

        Debug.Log(save.highscore);
        GlobalVariables.scores = save.scores;
        GlobalVariables.names = save.names;
        GlobalVariables.topscore = save.highscore;

        Debug.Log("Game Loaded");
      }
      else
      {
        Debug.Log("No game saved!");
      }
    }
}
