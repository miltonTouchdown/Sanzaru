using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioClip audio;
    private AudioSource source;
    public KeyCode respondTo;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update () {
		if (Input.GetKeyDown(respondTo))
        {
            source.PlayOneShot(audio);
        }
	}
}
