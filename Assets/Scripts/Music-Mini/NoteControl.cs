using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteControl : MonoBehaviour {
    public float speed = 5;
    public int points = 50;
    bool hit = false;

    void Start () {

	}

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Button") {
            Button1 tempb = col.gameObject.GetComponent<Button1>();
            if (tempb)
            if (tempb.isPressed && !hit) {
                    if (!hit)
                    {
                        GlobalVariables.score += points;
                        hit = true;
                    }
                    tempb.isRumbling = true;
            }
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Button")
        {
            Button1 tempb = col.gameObject.GetComponent<Button1>();
            if (tempb)
                tempb.isRumbling = false;
        }
    }

    void Update () {
        this.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        if (this.transform.position.z < -5)
            GameObject.Destroy(this.gameObject);
	}

}
