using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ChannelManager : MonoBehaviour {

	private List<FaderChannel> m_faderChannels = new List<FaderChannel>();
	private FaderChannel m_activeChannel;

	// Use this for initialization
	void Start () {
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
			throw new NullReferenceException(e.Message);
		}
	}

	/// <summary>
	/// Returns wether fader channel exists.
	/// </summary>
	/// <returns><c>true</c>, if channel exists, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	public bool FaderChannelExists(FaderChannel chan)
	{
		try
		{
			return m_faderChannels.Exists(x => x.ChannelName == chan.ChannelName);
		}
		catch (NullReferenceException e)
		{
			throw new NullReferenceException(e.Message);
		}
	}

	/// <summary>
	/// Adds a fader channel.
	/// </summary>
	/// <param name="chan">Chan.</param>
	public void AddFaderChannel(FaderChannel chan)
	{
		if (!FaderChannelExists(chan))
		{
			m_faderChannels.Add(chan);
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
			throw new NullReferenceException(e.Message);
		}
	}

	/// <summary>
	/// Sets the active channel.
	/// </summary>
	/// <param name="name">Name.</param>
	public void SetActiveChannel(FaderChannel chan)
	{
		if (m_activeChannel.ChannelName != chan.ChannelName && m_faderChannels.Exists(x => x.ChannelName == chan.ChannelName))
		{
			m_activeChannel.m_Active = false;
			m_activeChannel = m_faderChannels.Find (x => x.ChannelName == chan.ChannelName);
			m_activeChannel.m_Active = true;
		}
	}
}
