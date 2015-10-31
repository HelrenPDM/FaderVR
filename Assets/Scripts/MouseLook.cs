using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Fader
{
	[Serializable]
	public class MouseLook
	{
		public float XSensitivity = 2f;
		public float YSensitivity = 2f;
		public bool clampVerticalRotation = true;
		public float MinimumX = -90F;
		public float MaximumX = 90F;
		public bool smooth;
		public float smoothTime = 5f;
		
		private Quaternion m_CameraTargetRot;


		public void Init (Transform camera)
		{
			m_CameraTargetRot = camera.localRotation;
		}


		public void LookRotation (Transform character, Transform camera)
		{
			float yRot = CrossPlatformInputManager.GetAxis ("Mouse X") * XSensitivity;
			float xRot = CrossPlatformInputManager.GetAxis ("Mouse Y") * YSensitivity;

			m_CameraTargetRot *= Quaternion.Euler (-xRot, yRot, 0f);

			if (clampVerticalRotation)
				m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

			if (smooth) {
				camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
			} else {
				camera.localRotation = m_CameraTargetRot;
			}
		}


		Quaternion ClampRotationAroundXAxis (Quaternion q)
		{
			q.x /= q.w;
			q.y /= q.w;
			q.z /= q.w;
			q.w = 1.0f;

			float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

			angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

			q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

			return q;
		}

	}
}
