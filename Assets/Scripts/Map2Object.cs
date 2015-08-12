using UnityEngine;
using System.Collections;

public class Map2Object {

	public Map2Object()
	{
	}

	public void Tweet2Object(TwitterData tweet, int index)
	{
		GameObject tweetSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		tweetSphere.transform.LookAt(Vector3.zero);
		tweetSphere.transform.position = new Vector3((float)index * 10f, 0f, 0f);
		float scale = tweet.retweetCount;
		tweetSphere.transform.localScale = tweet.retweetCount > 0 ? new Vector3(scale, scale, scale) : new Vector3(0.5f, 0.5f, 0.5f);

		GameObject tweetText = new GameObject("text" + index);
		tweetText.AddComponent<TextMesh>();
		tweetText.GetComponent<TextMesh>().text = tweet.tweetText;
		tweetText.GetComponent<TextMesh>().fontSize = 72;
		tweetText.GetComponent<TextMesh>().color = Color.red;
		tweetText.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
		tweetText.GetComponent<TextMesh>().alignment = TextAlignment.Center;
		tweetText.GetComponent<TextMesh>().text = TrimText(tweetText.GetComponent<TextMesh>());

		Vector3 relpos = tweetSphere.transform.position;
		relpos.y += tweet.retweetCount + 2;
		tweetText.transform.position = relpos;
		tweetText.transform.localScale = new Vector3(.1f,.1f,.1f);
	}

	string TrimText(TextMesh tmesh)
	{
		string builder = "";
		float rowLimit = 1.9f; //find the sweet spot    
		string[] parts = tmesh.text.Split(' ');
		tmesh.text = "";
		for (int i = 0; i < parts.Length; i++)
		{
			tmesh.text += parts[i] + " ";
			if (tmesh.transform.GetComponent<Renderer>().bounds.extents.x > rowLimit)
			{
				tmesh.text = builder.TrimEnd() + System.Environment.NewLine + parts[i] + " ";
			}
			builder = tmesh.text;
		}
		return builder;
	}
}
