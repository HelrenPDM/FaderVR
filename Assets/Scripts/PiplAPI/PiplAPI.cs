using UnityEngine;
using System;
using System.Collections;
using Newtonsoft.Json;
using Pipl.APIs.Search;

public class PiplAPI : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		SearchAPIRequest request = new SearchAPIRequest (email: "clark.kent@example.com",
		                                                firstName: "Clark",
		                                                lastName: "Kent");
		SearchPipl (request);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private async IEnumerator SearchPipl (SearchAPIRequest request)
	{
		SearchAPIResponse response = await request.SendAsync (true);
		Debug.Log (response.ToString ());
	}
}
