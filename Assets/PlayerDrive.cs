using UnityEngine;
using System.Collections;

public class PlayerDrive : MonoBehaviour {

    public Transform [] NavPoints;
    public GameObject Player;

    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
        if (NavPoints.Length == 0)
            Debug.LogWarning ("No camera navigation points set.");
        else
        {
            Player = GameObject.FindGameObjectWithTag ("Player");
            Player.GetComponentInChildren<Camera> ().enabled = true;
            Player.transform.localPosition = NavPoints [0].position;
            StartCoroutine (PlayIntro ());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator PlayIntro()
    {
        foreach (Transform navPoint in NavPoints)
        {
            yield return StartCoroutine (LerpCam (navPoint));
        }
        yield return null;
    }

    IEnumerator LerpCam (Transform trans)
    {
        Vector3 start = this.transform.position;
        Vector3 end = trans.position;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(start, end);

        while (this.transform.position != end)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            this.transform.position = Vector3.Lerp (start, end, fracJourney);
            yield return null;
        }
        yield return null;
    }
}
