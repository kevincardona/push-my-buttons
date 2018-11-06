using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketball : MonoBehaviour {

    // Update is called once per frame

    float timer = 0f;
	void Update () {
        if (this.transform.position.y < -10)
            Destroy(this.gameObject);

        timer += Time.deltaTime;
        if (GetComponent<Rigidbody>().velocity.y < 0 && timer > .1)
        {
            timer = 0;
            Debug.Log("Basketball Position "+ transform.position);
        }
    }
}
