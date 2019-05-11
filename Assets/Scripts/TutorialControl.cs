using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : MonoBehaviour {

    public GameObject[] ArrowSounds;
    public GameObject BG, Instruction, arrowInstr;
    //public AudioClip clipUp, clipDown, clipLeft, clipRight;

    private int index;
    private AudioSource _source;

	void Start ()
    {
	}
	
	void Update () {
		
	}

    public void Init()
    {
        GetComponent<AudioSource>().Play();
        index = 0;

        LeanTween.scale(BG.GetComponent<RectTransform>(), BG.GetComponent<RectTransform>().localScale * 1.08f, 8f)
            .setDelay(1f).setOnCompleteOnRepeat(true).setLoopPingPong();

        LeanTween.alpha(Instruction.GetComponent<RectTransform>(), 0f, 1f)
            .setDelay(1f).setOnCompleteOnRepeat(true).setLoopPingPong(4);

        LeanTween.rotate(arrowInstr.GetComponent<RectTransform>(), 6.0f, 1.0f).setEase(LeanTweenType.easeOutElastic)
            .setOnCompleteOnRepeat(true).setLoopPingPong();

        setArrowButton();

    }

    public void setArrowButton()
    {
        LeanTween.scale(ArrowSounds[index].GetComponent<RectTransform>(), ArrowSounds[index].GetComponent<RectTransform>().localScale * 1.4f, 1f)
        .setDelay(1f).setOnStart(ArrowSounds[index].GetComponent<AudioSource>().Play).setOnCompleteOnRepeat(false).setLoopPingPong(1).
        setOnComplete(setArrowButton);

        if (index >= ArrowSounds.Length-1)
            index = 0;
        else
            index++;

    }

    public void Close()
    {
        foreach(GameObject btn in ArrowSounds)
        {
            LeanTween.cancel(btn);
            btn.transform.localScale = Vector3.one;
        }

        LeanTween.cancel(arrowInstr);
        arrowInstr.GetComponent<RectTransform>().rotation = Quaternion.identity;
    }
}
