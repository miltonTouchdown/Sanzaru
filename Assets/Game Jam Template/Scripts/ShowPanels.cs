using UnityEngine;
using System.Collections;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    public GameObject creditsPanel;
    public GameObject creditsTint;
    public GameObject levelsPanel;
    public CanvasGroup tint;

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
	{
        //optionsPanel.SetActive(true);
        //optionsTint.SetActive(true);
        ShowPanel(optionsPanel);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
        HidePanel(optionsPanel);
	}

    //Call this function to activate and display the Levels panel during the main menu
    public void ShowLevelsPanel()
    {
        ShowPanel(levelsPanel);
    }

    //Call this function to deactivate and hide the Levels panel during the main menu
    public void HideLevelsPanel()
    {
        HidePanel(levelsPanel);
    }


    //Call this function to activate and display the Credits panel during the main menu
    public void ShowCreditsPanel()
    {
        //creditsPanel.SetActive(true);
        //creditsTint.SetActive(true);
        ShowPanel(creditsPanel);
    }

    //Call this function to deactivate and hide the Credits panel during the main menu
    public void HideCreditsPanel()
    {
        //creditsPanel.SetActive(false);
        //creditsTint.SetActive(false);
        HidePanel(creditsPanel);
    }

    //Call this function to activate and display the main menu panel during the main menu
    public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

    public void ShowLevelsPanel(bool isVisible)
    {
        if (isVisible)
            ShowPanel(levelsPanel);
        else
            HidePanel(levelsPanel);
    }

    //Background black tint manager
    void ShowTint()
    {
        tint.gameObject.SetActive(true);
        tint.alpha = 0;
        LeanTween.alphaCanvas(tint, 0.5f, 0.5f);
    }

    void HideTint()
    {
        LeanTween.alphaCanvas(tint, 0, 0.3f).setOnComplete(() =>
        {
            tint.gameObject.SetActive(false);
        });
    }

    void ShowPanel(GameObject panel)
    {
        ShowTint();
        panel.SetActive(true);
        panel.transform.localScale = Vector3.zero;
        LeanTween.scale(panel, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutBack);
    }

    void HidePanel(GameObject panel)
    {
        HideTint();
        LeanTween.scale(panel, Vector3.zero, 0.2f).setOnComplete(() =>
        {
            panel.SetActive(false);
        });
    }
}
