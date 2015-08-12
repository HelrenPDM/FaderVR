using UnityEngine;
using System.Collections;

public class Map2Object {

	GameObject tweetSphere;
	GameObject tweetText;
	float floatAbove;

	public Map2Object()
	{
	}

	public void Tweet2Object(TwitterData tweet, int index)
	{
		if (tweet.
		tweetSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		floatAbove = tweet.retweetCount;
		tweetSphere.transform.localScale = tweet.retweetCount > 0 ? new Vector3(floatAbove, floatAbove, floatAbove) : new Vector3(0.5f, 0.5f, 0.5f);

		tweetText = new GameObject("text" + index);
		tweetText.AddComponent<TextMesh>();
		tweetText.GetComponent<TextMesh>().text = tweet.tweetText;
		tweetText.GetComponent<TextMesh>().fontSize = 72;
		tweetText.GetComponent<TextMesh>().color = Color.red;
		tweetText.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
		tweetText.GetComponent<TextMesh>().alignment = TextAlignment.Center;
		tweetText.GetComponent<TextMesh>().text = TrimText(tweetText.GetComponent<TextMesh>());
		tweetText.transform.SetParent (tweetSphere.transform);

		Vector3 relpos = tweetSphere.transform.position;
		relpos.y += floatAbove + 2;
		tweetText.transform.position = relpos;
		if (floatAbove < 3) {
			tweetText.transform.localScale = new Vector3 (.01f * floatAbove, .01f * floatAbove, .01f * floatAbove);
		} else {
			tweetText.transform.localScale = new Vector3 (.01f, .01f, .01f);
		}
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

	public void RingDistribution(int index, int count, Vector3 center)
	{
		tweetSphere.transform.position = RandomCircle (index, count, center, 50);
		//tweetSphere.transform.rotation = Quaternion.FromToRotation (Vector3.forward, center);
	}

    Vector3 RandomCircle(int index, int count, Vector3 center, float radius)
	{
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		return pos;
	}

}
