using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class Main : MonoBehaviour {

	Map2Object mapper;

	// Use this for initialization
	void Start () {
		TwitterAPI.instance.SearchTwitter("#sturm", ResultsCallBack);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ResultsCallBack(List<TwitterData> tweetList) {
		Debug.Log("====================================================");
		int i = -1;
		foreach(TwitterData twitterData in tweetList) {
			mapper = new Map2Object();

			i++;
			Debug.Log("Tweet: " + twitterData.ToString());
			mapper.Tweet2Object(twitterData, i);
		}
	}
}
