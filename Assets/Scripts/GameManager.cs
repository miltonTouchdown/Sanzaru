using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public StatusGame StatusCurrGame { get; set; }

    private static GameManager _instance = null;
    public static GameManager Instance
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

    void Start ()
    {
        StatusCurrGame = StatusGame.InitGame;
        UIManager.Instance.showTutorial(true);
	}

	void Update () {
		
	}

    public void InitGame()
    {
        StatusCurrGame = StatusGame.Playing;
        Instance.StartCoroutine(Instance.CountDown());
    }

    public void StartGame()
    {
        AudioManager.Instance.Init();
    }

    public void PauseGame(bool value)
    {
        if (value)
        {
            AudioManager.Instance.PauseBeat();
            StatusCurrGame = StatusGame.Pause;
        }
        else
        {
            AudioManager.Instance.Init();
            StatusCurrGame = StatusGame.Playing;
        }
    }

    public void EndGame(bool isGameOver)
    {
        StatusCurrGame = StatusGame.Ending;
        Debug.Log("End Game");
        UIManager.Instance.setActiveEndGame(true, isGameOver ? "Game Over" : "Level Complete!");
        AudioManager.Instance.StopBeat();
        Player.Instance.Init();
    }

    public void RestartGame()
    {
        UIManager.Instance.setActiveEndGame(false);
        AudioManager.Instance.StopBeat();
        Player.Instance.Init();
        InitGame();
    }

    private IEnumerator CountDown()
    {
        int i = 3;
        UIManager.Instance.setTextCountDown(i.ToString());
        AudioManager.Instance.PlaySound(SoundType.Countdown);
        while (i > 0)
        {
            yield return new WaitForSeconds(1f);
            i -= 1;
            AudioManager.Instance.PlaySound(SoundType.Countdown);
            UIManager.Instance.setTextCountDown(i.ToString());
        }
        UIManager.Instance.setActiveCountDown(false);
        StartGame();
    }

    public void LoadScene(string nameScene = null)
    {
        SceneManager.LoadScene(nameScene);
    }
}

public enum StatusGame { InitGame, Playing, Ending, Pause}
