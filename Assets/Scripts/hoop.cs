using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoop : MonoBehaviour {
    public int points = 50;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col);
        if (col.gameObject.tag == "basketball")
            GlobalVariables.score += points;
    }

}
