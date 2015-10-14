using UnityEngine;
using System.Collections;
using LMWidgets;

[RequireComponent(typeof(ScreenControl))]
public class ScreenToggle : DataBinderToggle
{
	void Start ()
	{
	}

	override public bool GetCurrentData ()
	{
		return gameObject.activeInHierarchy;
	}
	
	override protected void setDataModel (bool value)
	{
		gameObject.SetActive (value);
	}
}