using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClips : MonoBehaviour {

    public AudioClip[] acs;
    public AudioSource[] asources;
	// Use this for initialization
	void Start () {
		
	}
	
    public void playClip(){
        foreach(AudioSource asource in asources){
            if(!asource.isPlaying){
                asource.clip = acs[Random.Range(0,acs.Length)];
                asource.Play();
                return;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
