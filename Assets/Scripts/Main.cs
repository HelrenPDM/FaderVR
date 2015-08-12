using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class Main : MonoBehaviour {

	Map2Object mapper;

	// Use this for initialization
	void Start () {
		TwitterAPI.instance.SearchTwitter("#molested -filter:retweets", ResultsCallBack);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ResultsCallBack(List<TwitterData> tweetList) {
		Debug.Log("====================================================");
		int i = -1;

		Vector3 center = GameObject.Find ("rink").transform.position;
		foreach(TwitterData twitterData in tweetList) {
			mapper = new Map2Object();

			i++;
			Debug.Log("Tweet: " + twitterData.ToString());
			mapper.Tweet2Object(twitterData, i);
			mapper.RingDistribution(i, tweetList.Count, center);
		}
	}
}
