//
// TwitterChannel.cs
//
// Author:
//       Stephan Gensch <stgensch@vragments.com>
//
// Copyright (c) 2015 Stephan Gensch
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnityEngine;

using System;
using System.Collections.Generic;
using System.Collections;

namespace Fader {

	public class TwitterChannelBase {

		/// <summary>
		/// Gets or sets the name of the channel.
		/// </summary>
		/// <value>The name of the channel.</value>
		public string ChannelName { get; set; }
	
		/// <summary>
		/// Gets or sets the channel URI.
		/// </summary>
		/// <value>The channel URI.</value>
		public Uri ChannelUri { get; set; }
	
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="FaderChannel"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool m_Active { get; set; }
	
		/// <summary>
		/// The search terms.
		/// </summary>
		public List<string> m_SearchTerms;

		/// <summary>
		/// The m_ search results.
		/// </summary>
		public List<List<TwitterData>> m_SearchResults;

		/// Gets or sets a value indicating whether this <see cref="FaderChannel"/> is active.
		/// </summary>
		/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
		public bool Active {get;set;}

		// Use this for initialization
		void Start () {

		}
	
		// Update is called once per frame
		void Update () {

		}

		abstract void ResultsCallBack(List<TwitterData> tweetList) {
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

		public abstract void StartSimpleSearch(string searchTerm)
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

	}
}
