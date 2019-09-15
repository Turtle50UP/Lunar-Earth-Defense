using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Spawner {

    public float maxR;
    public float spawnR;
    public float spawnedVel;
    public float spawnedVelErr;
    public bool debug = false;
    public GameObject moon;
	// Use this for initialization
    public override GameObject spawn(int i){
        Vector3 thispos = this.transform.position;
        Vector3 velocity = Vector3.zero;
        float randangle = Random.Range(0f, 2 * Mathf.PI);
        Vector3 asterpos = new Vector3(Mathf.Cos(randangle), Mathf.Sin(randangle),0);
        GameObject go = base.spawn(i);
        if(go == null){
            return go;
        }
        go.transform.position = asterpos * spawnR + this.transform.position;
        velocity = -1f * asterpos * spawnedVel;
        velocity.z = 0;
        go.GetComponent<AsterMove>().velocity = velocity;
        go.GetComponent<AsterMove>().moon = moon;
        return go;
    }
	
	// Update is called once per frame
	void Update () {
        if(debug){
            if(Input.GetKeyDown(KeyCode.S)){
                spawn((int)Random.Range(0, 2.99f));
            }
        }
    }
}
