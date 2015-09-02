﻿//
// FaderEntityToObject.cs
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
using System.Collections;

namespace Fader {

	public class FaderEntityToObject<PayloadType> : MonoBehaviour {

		public PayloadType m_FaderEntity;

		public GameObject m_FaderObject;
		public Renderer m_Rend;
		public TextMesh m_FaderObjectText;

		[SerializeField]
		public float m_FaderObjectTextRowLimit = 2f;

		/// <summary>
		/// Initializes a new instance of the <see cref="Fader.FaderEntityToObject"/> class.
		/// </summary>
		public FaderEntityToObject()
		{
			m_FaderObject = new GameObject();
			m_Rend = new Renderer();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fader.FaderEntityToObject"/> class.
		/// </summary>
		/// <param name="data">Data.</param>
		public FaderEntityToObject(PayloadType data)
		{
			m_FaderObject = new GameObject();
			m_Rend = new Renderer();
			m_FaderEntity = data;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fader.FaderEntityToObject"/> class.
		/// </summary>
		/// <param name="data">Data.</param>
		/// <param name="primType">Prim type.</param>
		public FaderEntityToObject(PayloadType data, PrimitiveType primType)
		{
			m_FaderObject = new GameObject();
			m_Rend = new Renderer();
			m_FaderEntity = data;
			CreateObject(primType);
		}

		/// <summary>
		/// Creates the object.
		/// </summary>
		/// <param name="primType">Prim type.</param>
		public void CreateObject(PrimitiveType primType)
		{
			m_FaderObject = GameObject.CreatePrimitive(primType);
		}


		/// <summary>
		/// Positions the object.
		/// </summary>
		/// <param name="pos">Position.</param>
		public void PositionObject(Vector3 pos)
		{
			m_FaderObject.transform.position = pos;
		}

		/// <summary>
		/// Scales the object.
		/// </summary>
		/// <param name="scale">Scale.</param>
		public void ScaleObject(float scale)
		{
			m_FaderObject.transform.localScale = scale > 1f ? new Vector3(scale, scale, scale) : new Vector3(1f, 1f, 1f);
		}

		/// <summary>
		/// Creates the text component.
		/// </summary>
		/// <param name="text">Text.</param>
		public void CreateTextComponent(string text)
		{
			m_FaderObjectText = m_FaderObject.AddComponent<TextMesh>();
			m_FaderObjectText.text = text;
		}

		/// <summary>
		/// Sets the text component properties.
		/// </summary>
		/// <param name="fontSize">Font size.</param>
		/// <param name="color">Color.</param>
		/// <param name="anchor">Anchor.</param>
		/// <param name="alignment">Alignment.</param>
		/// <param name="trim">If set to <c>true</c> trim.</param>
		public void SetTextComponentProperties(int fontSize, Color color, TextAnchor anchor, TextAlignment alignment, bool trim)
		{
			m_FaderObjectText.fontSize = fontSize;
			m_FaderObjectText.color = color;
			m_FaderObjectText.anchor = anchor;
			m_FaderObjectText.alignment = alignment;

			if (trim)
			{
				m_FaderObjectText.text = TrimText(m_FaderObjectText);
			}
		}

		/// <summary>
		/// Sets the text component position.
		/// </summary>
		/// <param name="pos">Position.</param>
		public void SetTextComponentPosition(Vector3 pos)
		{
			m_FaderObjectText.transform.position = pos;
		}

		/// <summary>
		/// Sets the text component scale.
		/// </summary>
		/// <param name="scale">Scale.</param>
		public void SetTextComponentScale(float scale)
		{
			m_FaderObjectText.transform.localScale = scale > 1f ? new Vector3(scale, scale, scale) : new Vector3(1f, 1f, 1f);
		}

		/// <summary>
		/// Trims the text.
		/// </summary>
		/// <returns>The text.</returns>
		/// <param name="tmesh">Tmesh.</param>
		string TrimText(TextMesh tmesh)
		{
			string builder = "";
			string[] parts = tmesh.text.Split(' ');
			tmesh.text = "";
			for (int i = 0; i < parts.Length; i++)
			{
				tmesh.text += parts[i] + " ";
				if (tmesh.transform.GetComponent<Renderer>().bounds.extents.x > m_FaderObjectTextRowLimit)
				{
					tmesh.text = builder.TrimEnd() + System.Environment.NewLine + parts[i] + " ";
				}
				builder = tmesh.text;
			}
			return builder;
		}
	}
}