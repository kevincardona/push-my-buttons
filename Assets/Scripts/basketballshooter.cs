using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketballshooter : MonoBehaviour {
    public Button1 button;
    public GameObject basketball;
    public int speed;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame

    void Update () {
		if (button.newpress)
        {
            button.newpress = false;
            GameObject temp = Instantiate(basketball, this.transform.position, Quaternion.identity);
            Vector3 random = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            temp.GetComponent<Rigidbody>().AddForce(transform.up * speed + random);
            temp.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
        }
	}
}
