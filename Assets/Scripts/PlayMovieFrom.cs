using UnityEngine;
using System.Collections;

// Make sure we have gui texture and audio source
[RequireComponent(typeof(AudioSource))]
public class PlayMovieFrom : MonoBehaviour
{

	public string url = "http://www.unity3d.com/webplayers/Movie/sample.ogg";

	private MovieTexture movieTexture;
	private AudioSource aud;
	private Renderer rend;

	// Use this for initialization
	void Start ()
	{
		rend = GetComponent<Renderer> ();
		// Start download
		WWW www = new WWW (url);
	
		// Make sure the movie is ready to start before we start playing
		StartCoroutine (LoadandPlayMovie (www));
	}

	IEnumerator LoadandPlayMovie (WWW www)
	{
		movieTexture = www.movie;
		while (!movieTexture.isReadyToPlay) {
			yield return movieTexture.isReadyToPlay;
		}
		
		// Initialize gui texture to be 1:1 resolution centered on screen
		rend.material.mainTexture = (Texture)movieTexture;

		// Assign clip to audio source
		// Sync playback with audio
		aud = GetComponent<AudioSource> ();
		aud.clip = movieTexture.audioClip;

		// Play both movie & sound
		movieTexture.loop = true;
		aud.loop = true;
		movieTexture.Play ();
		aud.Play ();
	}
}