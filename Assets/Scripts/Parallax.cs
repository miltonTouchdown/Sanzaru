using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public float parallaxSpeed;
    private Vector2 lastCameraPosition;

	void Start () {
        lastCameraPosition = Camera.main.transform.position;
	}
	
	void Update () {
        Vector2 delta = (Vector2)Camera.main.transform.position - lastCameraPosition;
        lastCameraPosition = Camera.main.transform.position;
        transform.position += (Vector3) (delta * parallaxSpeed);
	}
}
