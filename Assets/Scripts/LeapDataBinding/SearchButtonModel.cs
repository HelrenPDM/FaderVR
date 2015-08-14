using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;

public class SearchButtonModel : DataBinderToggle {
	
	override public bool GetCurrentData() {
		return false;
	}
	
	override protected void setDataModel(bool value) {
	}
}
