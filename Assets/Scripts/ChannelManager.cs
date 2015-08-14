using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ChannelManager : MonoBehaviour {

	private List<FaderChannel> m_faderChannels = new List<FaderChannel>();
	private FaderChannel m_activeChannel;

	// Use this for initialization
	void Start () {
		FaderChannel tmpChan = new FaderChannel("Twitter");
		tmpChan.Active = true;
		m_faderChannels.Add(tmpChan);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Gets the fader channel list.
	/// </summary>
	/// <returns>The fader channel list.</returns>
	public List<FaderChannel> GetFaderChannelList()
	{
		try
		{
			return m_faderChannels;
		}
		catch (NullReferenceException e)
		{
			throw new NullReferenceException();
		}
	}

	/// <summary>
	/// Returns wether fader channel exists.
	/// </summary>
	/// <returns><c>true</c>, if channel exists, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	public bool FaderChannelExists(string name)
	{
		try
		{
			return m_faderChannels.Exists(x => x.ChannelName == name);
		}
		catch (NullReferenceException e)
		{
			throw new NullReferenceException();
		}
	}


	/// <summary>
	/// Gets the active channel.
	/// </summary>
	/// <returns>The active channel.</returns>
	public FaderChannel GetActiveChannel()
	{
		try
		{
			return m_activeChannel;
		}
		catch (NullReferenceException e)
		{
			throw new NullReferenceException();
		}
	}

	/// <summary>
	/// Sets the active channel.
	/// </summary>
	/// <param name="name">Name.</param>
	public void SetActiveChannel(string name)
	{
		if (m_activeChannel.ChannelName != name && m_faderChannels.Exists(x => x.ChannelName == name))
		{
			m_activeChannel.Active = false;
			m_activeChannel = m_faderChannels.Find (x => x.ChannelName == name);
			m_activeChannel.Active = true;
		}
	}
}
