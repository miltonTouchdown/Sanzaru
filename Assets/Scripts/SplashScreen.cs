using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public float visibleTime = 1f;
    public CanvasGroup panel;
	// Use this for initialization
	void Start () {
        LeanTween.delayedCall(visibleTime, () =>
        {
            LeanTween.alphaCanvas(panel, 0, 0.5f).setOnComplete(() =>
            {
                SceneManager.LoadScene("Menu");
            });
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
