using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {

    public Camera Camera;

	// Use this for initialization
	void Start () {
        Camera = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt (Camera.transform);
	}
}
