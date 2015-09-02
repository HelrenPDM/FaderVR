using UnityEngine;
using System;
using System.Collections;
using LMWidgets;

public class SliderRetweetThreshold : DataBinderSlider
{
	override protected void setDataModel(float value) {
		GetComponent<TwitterChannel>().retweetThreshold = (Int32)value;
	}
	
	override public float GetCurrentData() {
		return Convert.ToSingle(GetComponent<TwitterChannel>().retweetThreshold);
	}
}
