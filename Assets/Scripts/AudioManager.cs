using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public MainBeat mainBeat;

    public AudioClip Countdown;
    public AudioClip WrongMove, MovePlayer;
    public AudioClip SuccessLevel, Tutorial;

    private AudioSource _source;
    private Dictionary<SoundType, AudioClip> dictSound = new Dictionary<SoundType, AudioClip>();

    private static AudioManager _instance = null;
    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }

    void Start()
    {
        _source = GetComponent<AudioSource>();

        dictSound.Add(SoundType.Countdown, Countdown);
        dictSound.Add(SoundType.MovePlayer, MovePlayer);
        dictSound.Add(SoundType.Success, SuccessLevel);
        dictSound.Add(SoundType.WrongMove, WrongMove);
        dictSound.Add(SoundType.Tutorial, Tutorial);
    }

    public void Init()
    {
        PlayBeat();
        // TODO: reproducir notas
    }

    public void PlaySound(SoundType soundType)
    {
        _source.PlayOneShot(dictSound[soundType]);
    }

    public void PlayBeat()
    {
        mainBeat.Play();
    }

    public void PauseBeat()
    {
        mainBeat.Pause();
    }

    public void StopBeat()
    {
        mainBeat.Stop();
    }
}

public enum SoundType { Countdown, WrongMove, MovePlayer, Success, Tutorial}