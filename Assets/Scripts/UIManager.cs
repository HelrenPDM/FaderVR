using UnityEngine;
using System.Collections;
using Leap;

public class UIManager : MonoBehaviour {

	Controller m_Controller;
	GameObject m_LeapUI;

	void Awake () {
		m_Controller = new Controller ();
		if (m_Controller.IsServiceConnected()) {
		} else {
			m_LeapUI = GameObject.Find("UI_LEAP");
			m_LeapUI.SetActive (false);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
