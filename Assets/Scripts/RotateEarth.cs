using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour {

	Vector3 angvel;
	public float initSpeed;
	// Use this for initialization
	void Start()
	{
		angvel = Vector3.zero;
		angvel.z = initSpeed;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 eRotation = transform.rotation.eulerAngles;
		eRotation.z += angvel.z * Time.deltaTime;
		this.transform.eulerAngles = eRotation;
	}
}
