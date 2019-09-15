using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthStatSheet : MonoBehaviour {

	public float EarthMass;
	public float EarthRadius;
	// Use this for initialization
	void Start()
	{
        EarthMass = this.transform.localScale.x;
	}

	// Update is called once per frame
	void Update()
	{
        EarthMass = this.transform.localScale.x;
	}

    public void SetMass(float mass){
        this.transform.localScale = new Vector3(mass, mass, 1);
        Debug.Log(transform.localScale);
    }
}
