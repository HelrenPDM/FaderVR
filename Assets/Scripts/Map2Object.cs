using UnityEngine;
using System.Collections;

public class Map2Object {

	GameObject m_TweetSphere;
	GameObject m_TweetText;
	float m_Scale;

	public Map2Object()
	{
	}

	public void Tweet2Object(TwitterData tweet, int index)
	{
		m_TweetSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		m_Scale = tweet.retweetCount;
		m_TweetSphere.transform.localScale = tweet.retweetCount > 0 ? new Vector3(m_Scale, m_Scale, m_Scale) : new Vector3(0.5f, 0.5f, 0.5f);

		m_TweetText = new GameObject("text" + index);
		m_TweetText.transform.position = m_TweetSphere.transform.position;
		m_TweetText.AddComponent<TextMesh>();
		m_TweetText.GetComponent<TextMesh>().text = tweet.tweetText;
		m_TweetText.GetComponent<TextMesh>().fontSize = 90;
		m_TweetText.GetComponent<TextMesh>().color = Color.red;
		m_TweetText.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
		m_TweetText.GetComponent<TextMesh>().alignment = TextAlignment.Center;
		m_TweetText.GetComponent<TextMesh>().text = TrimText(m_TweetText.GetComponent<TextMesh>());
		m_TweetText.transform.SetParent (m_TweetSphere.transform);
		m_TweetText.transform.localScale = new Vector3(.025f,.025f,.025f);
	}

	string TrimText(TextMesh tmesh)
	{
		string builder = "";
		float rowLimit = 30f; //find the sweet spot    
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
		m_TweetSphere.transform.position = RandomCircle (index, count, center, 30);
		m_TweetText.transform.rotation = Quaternion.LookRotation(m_TweetText.transform.position - center);
	}

    Vector3 RandomCircle(int index, int count, Vector3 center, float radius)
	{
		float ang = (index * (360/count));
		Debug.Log("Angle of tweet " + index + ": " + ang);
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		return pos;
	}

}
