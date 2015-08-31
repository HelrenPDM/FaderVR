using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class TwitterChannel : MonoBehaviour {

	public string searchTerms;
	public int retweetThreshold = 0;
	public bool filterRetweets = true;
	/// Gets or sets a value indicating whether this <see cref="FaderChannel"/> is active.
	/// </summary>
	/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
	public bool Active {get;set;}

	private string searchTermsUI;

	List<TwitterData> filteredTweetList = new List<TwitterData>();

	Tweet2Sphere[] mapper;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUIText ();
	}

	void ResultsCallBack(List<TwitterData> tweetList) {
		Debug.Log("====================================================");

		Vector3 center = GameObject.Find ("rink").transform.position;
		foreach(TwitterData twitterData in tweetList) {
			if (twitterData.retweetCount >= retweetThreshold) {
				filteredTweetList.Add(twitterData);
			}
		}

		int count = filteredTweetList.Count;
		float step = 360f / (float)count;

		filteredTweetList.TrimExcess();
		mapper = new Tweet2Sphere[filteredTweetList.Count];
		int i = 0;
		Debug.Log("Array size: " + mapper.Length);
		foreach(TwitterData filteredData in filteredTweetList)
		{
			Debug.Log("Tweet: " + filteredData.ToString());
			mapper[i] = new Tweet2Sphere();
			mapper[i].Tweet2Object(filteredData, i);
			mapper[i].RingDistribution(i, step, center);
			i++;
		}
	}

	public void StartSearch()
	{
		if (mapper != null)
		{
			if (mapper.Length > 0)
			{
				foreach (var tweet in mapper)
				{
					DestroyImmediate(tweet.m_TweetSphere);
					DestroyImmediate(tweet.m_TweetText);
				}
				filteredTweetList.Clear();
			}
		}

		if (filterRetweets)
		{
			string tmp = searchTerms + " -filter:retweets";
			TwitterAPI.instance.SearchTwitter(tmp, ResultsCallBack);
		}
		else
		{
			TwitterAPI.instance.SearchTwitter(searchTerms, ResultsCallBack);
		}
	}

	void UpdateUIText()
	{
		GameObject.Find ("searchTermsUI").GetComponent<TextMesh> ().text = searchTerms;
	}
}
