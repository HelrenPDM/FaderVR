using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;

public class SearchTermDialModel : DataBinderDial {

	[SerializeField]
	string searchTerm = "Fader"; //Data model
	
	override protected void setDataModel(string value) {
		searchTerm = value;
		switch(searchTerm){
		case "Child Abuse":
			GetComponent<Main>().searchTerms = "Child Abuse";
			break;
		case "Sexual Abuse":
			GetComponent<Main>().searchTerms = "Sexual Abuse";
			break;
		case "Molested":
			GetComponent<Main>().searchTerms = "Molested";
			break;
		case "Royal Commission":
			GetComponent<Main>().searchTerms = "Royal Commission";
			break;
		case "Disfellowship":
			GetComponent<Main>().searchTerms = "Disfellowship";
			break;
		default:
			break;
		}
	}
	
	override public string GetCurrentData() {
		return searchTerm;
	}
}

