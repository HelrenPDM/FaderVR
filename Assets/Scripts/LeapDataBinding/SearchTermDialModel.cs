using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;

public class SearchTermDialModel : DataBinderDial {

	override protected void setDataModel(string value) {
		GetComponent<TwitterChannel>().searchTerms = value;
	}
	
	override public string GetCurrentData() {
		return GetComponent<TwitterChannel>().searchTerms;
	}
}

