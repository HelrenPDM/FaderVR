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

	TextMesh m_STUI;
	TextMesh m_RTTUI;

	List<TwitterData> filteredTweetList = new List<TwitterData>();

	FaderTweet[] mapper;

	// Use this for initialization
	void Start () {
		m_STUI = GameObject.Find ("searchTermsUI").GetComponent<TextMesh> ();
		m_RTTUI = GameObject.Find ("RTThresholdCount").GetComponent<TextMesh> ();
		#if UNITY_STANDALONE_OSX
		StartSearch();
		#endif
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
		mapper = new FaderTweet[filteredTweetList.Count];
		int i = 0;
		Debug.Log("Array size: " + mapper.Length);
		foreach(TwitterData filteredData in filteredTweetList)
		{
			Debug.Log("Tweet: " + filteredData.ToString());
			mapper[i] = new FaderTweet();
			mapper[i].CreateSphere(filteredData, i);
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
					DestroyImmediate(tweet.TweetSphere);
					DestroyImmediate(tweet.TweetText);
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

	public void RingDistribution(int index, float step, Vector3 center)
	{
		TweetSphere.transform.position = RandomCircle (index, step, center, 30);
		TweetText.transform.rotation = Quaternion.LookRotation(TweetText.transform.position - center);
	}
	
	Vector3 RandomCircle(int index, float step, Vector3 center, float radius)
	{
		float ang = (index * step);
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		return pos;
	}

	void UpdateUIText()
	{
		m_STUI.text = searchTerms;
		m_RTTUI.text = retweetThreshold.ToString();
	}
}
