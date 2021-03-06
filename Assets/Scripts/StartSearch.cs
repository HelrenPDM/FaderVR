//
// StartSearch.cs
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
using System;
using System.Collections.Generic;

namespace Fader
{
	public class StartSearch : MonoBehaviour
	{
		public ButtonDemo SimpleButton;
		public TwitterChannelBase m_TwitterChannel;

		// Use this for initialization
		void Start ()
		{
			m_TwitterChannel = FindObjectOfType<TwitterChannelBase> ();
			SimpleButton.StartHandler += OnSimpleButtonAction;
		}

		private void OnSimpleButtonAction (object sender, LMWidgets.EventArg<bool> arg)
		{
			Debug.Log (this.transform.name + " pressed.");
			foreach (string item in m_TwitterChannel.m_SearchTerms)
			{
				m_TwitterChannel.StartSimpleSearch (item, true);
			}
		}
	}
}