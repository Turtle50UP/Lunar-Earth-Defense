using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterMove : MonoBehaviour {

    public Vector3 velocity;
    public GameObject moon;
    Vector3 sysCenter;
	// Use this for initialization
	void Start () {
        sysCenter = new Vector3(3f, 0, -5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 thispos = this.transform.position;
        thispos += velocity * Time.deltaTime;
        this.transform.position = thispos;
	}
}
