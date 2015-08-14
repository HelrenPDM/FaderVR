using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;

public class ChannelDialModel : DataBinderDial {

	override protected void setDataModel(string value) {
		GetComponent<ChannelManager>().SetActiveChannel(value);
	}
	
	override public string GetCurrentData() {
		return GetComponent<ChannelManager>().GetActiveChannel().ToString();
	}
}

