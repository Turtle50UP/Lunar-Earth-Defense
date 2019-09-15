using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonConsume : MonoBehaviour {

	public AsteroidSpawner asts;
    public AudioClips acs;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		asts.despawn(collision.gameObject.name);
        acs.playClip();
	}
}
