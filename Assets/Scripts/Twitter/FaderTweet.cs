using UnityEngine;

using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Fader tweet.
/// </summary>
public class FaderTweet : MonoBehaviour {

	#region public variables
	// visual entities
	public GameObject TweetSphere { get; private set; }
	public GameObject TweetText { get; private set; }
	public GameObject TweetImage { get; private set; }

	// tweet payload
	public TwitterData Tweet { get; private set; }

	// position, size, opacity
	public Vector3 Position { get; private set; }
	public float Scale { get; private set; }
	#endregion

	#region private variables
	private Renderer m_Rend;
	#endregion

	/// <summary>
	/// Initializes a new instance of the <see cref="FaderTweet"/> class.
	/// </summary>
	/// <param name="tweet">Tweet.</param>
	public FaderTweet(TwitterData tweet)
	{
		Tweet = tweet;
	}

	public void CreateSphere()
	{
		Scale = Tweet.retweetCount;
		TweetSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		TweetSphere.name = Tweet.tweetID;
		TweetSphere.transform.localScale = Tweet.retweetCount > 0 ? new Vector3(Scale, Scale, Scale) : new Vector3(0.5f, 0.5f, 0.5f);
	}

	public void CreateText()
	{
		TweetText = new GameObject("text_" + Tweet.tweetID);
		TweetText.transform.position = TweetSphere.transform.position;
		TweetText.AddComponent<TextMesh>();
		TweetText.GetComponent<TextMesh>().text = Tweet.tweetText;
		TweetText.GetComponent<TextMesh>().fontSize = 90;
		TweetText.GetComponent<TextMesh>().color = Color.red;
		TweetText.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
		TweetText.GetComponent<TextMesh>().alignment = TextAlignment.Center;
		TweetText.GetComponent<TextMesh>().text = TrimText(TweetText.GetComponent<TextMesh>());
		TweetText.transform.SetParent (TweetSphere.transform);
		TweetText.transform.localScale = new Vector3(.025f,.025f,.025f);
	}

	string TrimText(TextMesh tmesh)
	{
		string builder = "";
		float rowLimit = 30f; //find the sweet spot    
		string[] parts = tmesh.text.Split(' ');
		tmesh.text = "";
		foreach (string part in parts)
		{
			tmesh.text += part + " ";
			if (tmesh.transform.GetComponent<Renderer>().bounds.extents.x > rowLimit)
			{
				builder += System.Environment.NewLine + part + " ";
				tmesh.text = "";
			}
			else
			{
				builder += part + " ";
			}
			//Debug.Log("builder step: " + builder);
		}
		return builder;
	}
}
