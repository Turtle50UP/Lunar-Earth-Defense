using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour {

    public float angaccel;
    Vector3 angvel;
    public float initSpeed;
    public float moveFactor;
	// Use this for initialization
	void Start () {
        angvel = Vector3.zero;
        angvel.z = angaccel * initSpeed;
	}
	
	// Update is called once per frame
    void FixedUpdate () {
        Vector3 eRotation = transform.rotation.eulerAngles;
        if (Input.GetAxis("Horizontal") < 0)
        {
            angvel.z = angaccel * moveFactor * initSpeed;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            angvel.z = angaccel * -moveFactor * initSpeed;
        }
        else{
            angvel.z = angaccel * initSpeed;
        }
        eRotation.z += angvel.z * Time.deltaTime;
        this.transform.eulerAngles = eRotation;
	}
}
