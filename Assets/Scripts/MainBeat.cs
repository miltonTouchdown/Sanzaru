using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBeat : MonoBehaviour {

    public float beatfrequency = 90f;
    public bool isPlaying { get; set; }

    private float beat;
    private AudioSource _source;
    private float bps = 0;              // beats x seconds
    private float timeTemp = 0;

    void Start ()
    {
        _source = GetComponent<AudioSource>();
        bps = 60f/beatfrequency*2f;
        beat = bps;
        isPlaying = false;
    }

	void Update () {

        if (isPlaying)
        {
            if (beat <= _source.time)
            {
                beat += bps;

                if (OnBeatAction != null)
                    OnBeatAction(MoveType.None);
            }

            // Detectar cuando el sonido loopea
            if (timeTemp <= _source.time)
                timeTemp = _source.time;
            else
            {
                beat = bps;
                timeTemp = 0;
            }
        }
    }

    public void Play()
    {
        isPlaying = true;
        _source.Play();
    }

    public void Pause()
    {
        isPlaying = false;
        _source.Pause();
    }

    public void Stop()
    {
        isPlaying = false;
        beat = bps;
        timeTemp = 0;
        _source.Stop();
    }

    public delegate void onBeat(MoveType move);
    public static event onBeat OnBeatAction;
}
