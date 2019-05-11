using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public MoveType nextMove;
    public int posCell;
    public int nextCell, previousCell;
    public bool sound = true;
    public AudioClip audio;

    private AudioSource _source;

	void Start ()
    {
        _source = GetComponent<AudioSource>();
	}

    public void PlaySoundCell()
    {
        if (sound)
            _source.PlayOneShot(audio);
    }
}

public enum MoveType{None, Right, Left, Up, Down}