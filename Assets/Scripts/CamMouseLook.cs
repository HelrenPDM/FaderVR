using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

using System.Collections;

namespace Fader
{
	public class CamMouseLook : MonoBehaviour
	{

		[SerializeField]
		private MouseLook
			m_MouseLook;

		private Camera m_Camera ;

		// Use this for initialization
		void Start ()
		{
			m_Camera = Camera.main;
			m_MouseLook.Init (m_Camera.transform);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	}
}
