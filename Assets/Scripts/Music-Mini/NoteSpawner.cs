using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour {

    public Vector3[] spawners;
    public GameObject[] noteObjs;
    public float distance;
    GameObject controllerBoard;
    public LevelManager manager;

    // The idea is to give spawner a localized version of music
    // and it will spawn accordingly given its distance + notespeed

    void Start()
    {
        //Create Spawners
        GameObject[] buttons = FindObjectOfType<ControllerBoard>().buttonPrefabs;
        spawners = new Vector3[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            spawners[i] = new Vector3(buttons[i].transform.position.x,
                buttons[i].transform.position.y - 0.01f,
                buttons[i].transform.position.z + distance);
        }
        manager = GetComponent<LevelManager>();
    }

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        /*if (timer > 1)
        {
            timer = 0;
            Instantiate(note, spawners[1], Quaternion.identity);
        }
        */
        /*if (timer > 5f)
        {
            manager.nextLevel();
        }*/

        if (timer >= 2.5f +37.89f) {
            Debug.Log("CHANGING Scene");
            manager.nextLevel();
        }
    }

    string possible = "ABCDEFG";

    public void playNote(string notes)
    {
        foreach (char tnote in notes)
        {
            int notenum = possible.IndexOf(tnote);
            if (notenum != -1)
            {
                float noteloc = ((float)notenum / (float)possible.Length) * spawners.Length;
                Instantiate(noteObjs[(int)noteloc], spawners[(int)noteloc] , Quaternion.identity);
            }
        }
    }

}
