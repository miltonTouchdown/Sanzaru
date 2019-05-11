using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour {

    private Light light;
    private float originalRange;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        originalRange = light.range;
        InvokeRepeating("UpdateLightRange", 0.0f, 0.1f);
    }
	
	void UpdateLightRange () {
        float timePassed = Time.time;
        timePassed = timePassed - Mathf.Floor(timePassed);

        light.range = originalRange * (-Mathf.Sin(timePassed * 10 * Mathf.PI) * 0.01f + 0.999f);
	}
}
