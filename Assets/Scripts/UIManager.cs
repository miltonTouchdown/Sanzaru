using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject UIplay, UIPause, UIEndGame, UICountDown, UITutorial;
    public GameObject btnMenu;

    private static UIManager _instance = null;
    public static UIManager Instance
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
    
    void Start () {
		
	}
	
	void Update () {
		
	}

    public void showTutorial(bool value)
    {
        UITutorial.SetActive(value);
        if (value)
        {
            UITutorial.GetComponent<TutorialControl>().Init();
        }
        else
        {
            if (GameManager.Instance.StatusCurrGame == StatusGame.InitGame)
            {
                GameManager.Instance.InitGame();
            }
        }
    }

    public void setActivePlayMenu(bool value)
    {
        UIplay.SetActive(value);
    }

    public void PlayGame()
    {
        GameManager.Instance.InitGame();
        setActivePlayMenu(false);
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
        UIPause.SetActive(false);
        setActiveCountDown(true);
    }

    public void PauseGame(bool value)
    {

        GameManager.Instance.PauseGame(value);
        UIPause.SetActive(value);

        if (value)
        {
            GameObject panelPause = UIPause.transform.GetChild(0).gameObject;
            panelPause.transform.localScale = Vector3.zero;
            LeanTween.scale(panelPause, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutBack);
        }
        else
        {

        }
    }

    public void setActiveEndGame(bool value, string message = "Game Over")
    {
        UIEndGame.SetActive(value);
        UIEndGame.GetComponentInChildren<Text>().text = message;
    }

    public void setActiveCountDown(bool value)
    {
        CanvasGroup countdown = UICountDown.GetComponent<CanvasGroup>();
        if (value)
        {
            UICountDown.SetActive(value);
            countdown.alpha = 0;
            LeanTween.alphaCanvas(countdown, 1, 0.4f);

            //btn menu
            LeanTween.moveX(btnMenu.GetComponent<RectTransform>(), -62, 0.2f);

        }
        else
        {
            LeanTween.alphaCanvas(countdown, 0, 0.2f).setOnComplete(() =>
            {
                UICountDown.SetActive(false);
                LeanTween.moveX(btnMenu.GetComponent<RectTransform>(), 62, 0.5f).setEase(LeanTweenType.easeOutBack);
            });
        }
    }

    public void setTextCountDown(string value)
    {
        string[] txtGo = { "¡A por ellos!", "¡Cumbia!", "¡Sarna!", "¡Go!", "¡Pablo!", "¡Joder!", "¡Empezad!", "¡Id!", "¡Ostia!",
            "¡GameJam!", "¡Enhoranbuena!", "¡Concha!", "¡Te odio!" };
        if (value == "0") value = txtGo[Mathf.FloorToInt(Random.Range(0, txtGo.Length))];

        Text lblCountdown = UICountDown.transform.GetChild(0).GetComponent<Text>();
        lblCountdown.text = value;
        lblCountdown.transform.localScale = Vector3.zero;
        LeanTween.scale(lblCountdown.gameObject, Vector3.one * 1.2f, 0.2f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
        {
            LeanTween.scale(lblCountdown.gameObject, Vector3.zero, 0.8f).setEase(LeanTweenType.easeInCubic);
        });
        
    }
}
