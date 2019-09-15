using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthConsume : MonoBehaviour {

    public AsteroidSpawner asts;
    public AudioClips acs;
    float actualRate;
    public float consumeRate;
	// Use this for initialization
	void Start () {
        actualRate = consumeRate;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float temp = consumeRate;
        if(collision.gameObject.name.Contains("AsteroidL")){
            temp *= 2f;
        }
        else if(collision.gameObject.name.Contains("AsteroidS")){
            temp /= 2f;
        }
        asts.despawn(collision.gameObject.name);
        this.transform.localScale += new Vector3(temp,temp,0);
        acs.playClip();
    }

    public void Lock(){
        consumeRate = 0f;
    }

    public void Unlock(){
        consumeRate = actualRate;
    }
}
