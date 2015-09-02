//
// FaderChannel.cs
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

using System;
using UnityEngine;

/// <summary>
/// Fader channel.
/// </summary>
public class FaderChannel : MonoBehaviour
{
	/// <summary>
	/// Gets or sets the name of the channel.
	/// </summary>
	/// <value>The name of the channel.</value>
	public string ChannelName { get; set; }
	/// <summary>
	/// Gets or sets the channel URI.
	/// </summary>
	/// <value>The channel URI.</value>
	public Uri ChannelUri { get; set; }
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="FaderChannel"/> is active.
	/// </summary>
	/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
	public bool m_Active { get; set; }

	//// <summary>
	/// Initializes a new instance of the <see cref="FaderChannel"/> class.
	/// </summary>
	public FaderChannel()
	{
		this.ChannelName = "";
		this.ChannelUri = new Uri("");
		this.m_Active = false;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="FaderChannel"/> class.
	/// </summary>
	/// <param name="name">Name.</param>
	public FaderChannel(string name)
	{
		this.ChannelName = name;
		this.m_Active = false;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="FaderChannel"/> class.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="uri">URI.</param>
	public FaderChannel(string name, Uri uri)
	{
		this.ChannelName = name;
		this.ChannelUri = uri;
		this.m_Active = false;
	}

	public void ToggleActive()
	{
		m_Active = !m_Active;
	}
}