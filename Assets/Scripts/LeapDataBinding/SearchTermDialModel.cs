﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;

public class SearchTermDialModel : DataBinderDial {

	override protected void setDataModel(string value) {
		GetComponent<TwitterMain>().searchTerms = value;
	}
	
	override public string GetCurrentData() {
		return GetComponent<TwitterMain>().searchTerms;
	}
}

