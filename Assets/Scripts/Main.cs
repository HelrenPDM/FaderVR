using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class Main : MonoBehaviour {

	public string searchTerms;

	Map2Object[] mapper;

	// Use this for initialization
	void Start () {
		TwitterAPI.instance.SearchTwitter(searchTerms, ResultsCallBack);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ResultsCallBack(List<TwitterData> tweetList) {
		Debug.Log("====================================================");
		int i = 0;

		Debug.Log(tweetList.Count);

		Vector3 center = GameObject.Find ("rink").transform.position;
		foreach(TwitterData twitterData in tweetList) {
			if (twitterData.retweetCount > 0) {
			Debug.Log("Tweet: " + twitterData.ToString());
				mapper[i] = new Map2Object();
				mapper[i].Tweet2Object(twitterData, i);
				mapper[i].RingDistribution(i, tweetList.Count, center);
				i++;
			}
		}
	}
}
