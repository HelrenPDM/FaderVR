using UnityEngine;
using System.Collections;
using LMWidgets;

public class TwitterToggleButton : MonoBehaviour {
	
	public ButtonDemoToggle ToggleButton;
	public TwitterChannel m_TwitterChannel;
	
	// Use this for initialization
	void Start () {
		m_TwitterChannel = GetComponent<TwitterChannel>();
		ToggleButton.StartHandler += OnSimpleButtonAction;
	}
	
	private void OnSimpleButtonAction (object sender, LMWidgets.EventArg<bool> arg) {
		Debug.Log(this.transform.name + " pressed.");
		m_TwitterChannel.Active = !m_TwitterChannel.Active;
	}
}