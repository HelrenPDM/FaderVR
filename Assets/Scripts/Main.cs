using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TwitterAPI.instance.SearchTwitter("#GDC", ResultsCallBack);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ResultsCallBack(List<TwitterData> tweetList) {
		Debug.Log("====================================================");
		foreach(TwitterData twitterData in tweetList) {
			Debug.Log("Tweet: " + twitterData.ToString());
		}
	}
}
