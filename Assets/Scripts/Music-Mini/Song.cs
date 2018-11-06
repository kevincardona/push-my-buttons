using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Song : MonoBehaviour {
    public float startDelay;

    /*

          SONGS

    */

    string songtext = "F 0 B 0 D 2.105 G 0 D 0.263125 G 0 D 0.263125" +
        " G 0 C 1.1840625 F 0 C 1.0525 A 0 F 1.0525 D 0 E 0.263125 D 0 D 0.789375 G 0 B 0.263125 F 0" +
        " G 0.789375 C 0.52625 F 0.263125 C 0.52625 G 0.52625 C 0.52625 G 0.52625" +
        " F 0.263125 E 0.52625 E 0.52625 F 0 E 0.263125 F 0 E 0.263125 F 0 E 1.0525 F 0 E 0.263125 F 0 E 0.263125 F 0" +
        " D 1.0525 E 0 A 0.52625 C 0" +
        " F 0.52625 B 0 D 2.105 G 0 D 0.263125 G 0 D 0.263125" +
        " G 0 E 0.52625 G 0 E 0.263125 G 0 E 0.263125 G 0 B 0.52625 F 0.263125 A 0.263125 C 0.263125" +
        " A 0.52625 F 0.52625 E 0.52625 D 0 D 1.0525 B 0 B .75 G 0.263125"+
        " D 0.263125 C 0.263125 B 0.52625 G 0.263125 C 0.263125 A 0.263125 F 0.263125 C 0.263125" +
        " B 0.263125 F 0.52625 F 0.263125 D 0.263125 B 0.263125 E 0.263125 C 0 E 0.263125 C 0 E 0.263125 C 0";

    /*"C 0.25 B 0 G 0 F 0.25 C 0 B 0.25 G 0.25 F 0.25C " +
    "0.25 B 0.25 C 0.25 F 0.25C 0.25 G 0.25 C 0.25 F 0.25C 0.25 G 0.25 C 0.25 F 0.25" +
    "0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25" +
    "0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25" +
    "0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25" +
    "0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25" +
    "0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25" +
    "0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25C 0.25 B 0.25 C 0.25 F 0.25";


    /*

        END

    */

    public NoteSpawner spawner;

    public class Note {
        public char note;
        public float deltatime;

        public Note(char nnote, float delta)
        {
            note = nnote;
            deltatime = delta;
        }
    }

    List<Note> song = new List<Note>();
    AudioSource source;

    void Start() {
        string[] notes = songtext.Split(' ');

        for (int i = 0; i < notes.Length - 1; i += 2)
        {

            float ttime;
            float.TryParse(notes[i + 1], out ttime);
            song.Add(new Note(notes[i][0], ttime));
        }
        GameObject[] destroy = GameObject.FindGameObjectsWithTag("music");
        spawner = GetComponentInChildren<NoteSpawner>();
        for (int i = 0; i < destroy.Length - 1; i++)
            if (i == 0)
                destroy[i].GetComponent<AudioSource>().Stop();
            else
                GameObject.Destroy(destroy[i]);
        source = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
    }

    float timer = 0;
    float songtimer = 0;
    bool isPlaying = true;
    bool sourceplay = false;

	void Update () {
        timer += Time.deltaTime;


        if (songtimer >= startDelay) {
            if (!sourceplay)
                source.Play();
            sourceplay = true;
        } else
        {
            songtimer += Time.deltaTime;
        }
        string notes = "";
        if (isPlaying)
        {
            if (song.Count <= 0)
            {
                isPlaying = false;
            }
            else while (timer >= song[0].deltatime)
            {
                notes += song[0].note;
                song.RemoveAt(0);
                if (song.Count <= 0)
                {
                    spawner.playNote(notes);
                    return;
                }
                timer = 0;
            }
            spawner.playNote(notes);
        }
	}
}
