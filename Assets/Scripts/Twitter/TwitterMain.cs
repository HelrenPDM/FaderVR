﻿using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class TwitterMain : MonoBehaviour {

	public string searchTerms;
	public int retweetThreshold = 0;
	public bool filterRetweets = true;

	List<TwitterData> filteredTweetList = new List<TwitterData>();

	Tweet2Sphere[] mapper;

	// Use this for initialization
	void Start () {
		if (filterRetweets)
		{
			searchTerms += " -filter:retweets";
		}
		TwitterAPI.instance.SearchTwitter(searchTerms, ResultsCallBack);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void ResultsCallBack(List<TwitterData> tweetList) {
		Debug.Log("====================================================");

		Vector3 center = GameObject.Find ("rink").transform.position;
		foreach(TwitterData twitterData in tweetList) {
			if (twitterData.retweetCount >= retweetThreshold) {
				filteredTweetList.Add(twitterData);
			}
		}

		mapper = new Tweet2Sphere[filteredTweetList.Count];
		int i = 0;
		Debug.Log("Array size: " + mapper.Length);
		foreach(TwitterData filteredData in filteredTweetList)
		{
			Debug.Log("Tweet: " + filteredData.ToString());
			mapper[i] = new Tweet2Sphere();
			mapper[i].Tweet2Object(filteredData, i);
			mapper[i].RingDistribution(i, tweetList.Count, center);
			i++;
		}
	}

	public void StartSearch()
	{
		if (filterRetweets)
		{
			searchTerms += " -filter:retweets";
		}
		TwitterAPI.instance.SearchTwitter(searchTerms, ResultsCallBack);

	}
}
