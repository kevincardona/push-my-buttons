using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Button1 : MonoBehaviour {

    public bool isPressed = false;
    public bool wasfp = false;
    public bool newpress = false;
    public bool forcePress = false;
    public bool isRumbling = false;
    public ushort rumbleIntensity = 3999;

    Animator anim;
    public AudioSource click;
    private Interactable interactable;

    void Start () {
        anim = GetComponent<Animator>();
        click = GetComponent<AudioSource>();
        interactable = this.GetComponent<Interactable>();
    }

    void Update() {
        if (isPressed) {
            anim.SetBool("press", true);
        } else {
            anim.SetBool("press", false);
        }
        if (forcePress)
        {
            wasfp = true;
            isPressed = true;
            anim.SetBool("press", true);
        }
        if (wasfp && !forcePress)
        {
            wasfp = false;
            isPressed = false;
            anim.SetBool("press", false);
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.tag == "Controller")
        {
            anim.SetBool("press", true);
            isPressed = true;
        }
        if (col.gameObject.name == "LeftHand" && isRumbling)
        {
            Hand hand = GameObject.Find("LeftHand").GetComponent<Hand>();
            hand.TriggerHapticPulse(rumbleIntensity);
        }
        if (col.gameObject.name == "RightHand" && isRumbling)
        {
            Hand hand = GameObject.Find("RightHand").GetComponent<Hand>();
            hand.TriggerHapticPulse(rumbleIntensity);
        }
    }
    /*
    private void OnHandHoverBegin(Hand hand)
    {
        Debug.Log("TEST");
        hand.TriggerHapticPulse(5000);
    }
    */

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.gameObject.name == "LeftHand")
        {
            Debug.Log("LHAND");
            if (!click.isPlaying)
                click.Play();
            Hand hand = GameObject.Find("LeftHand").GetComponent<Hand>();
            hand.TriggerHapticPulse(5000);
        }
        if (col.gameObject.name == "RightHand")
        {
            if (!click.isPlaying)
                click.Play();
            Debug.Log("RHAND");
            Hand hand = GameObject.Find("RightHand").GetComponent<Hand>();
            hand.TriggerHapticPulse(5000);
        }
        newpress = true;
    }


    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "Controller")
        {
            anim.SetBool("press", false);
            isPressed = false;
        }
    }
}
