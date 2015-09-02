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
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Fader channel.
/// </summary>
namespace Fader {

	public abstract class FaderChannel<ChannelType> : MonoBehaviour
	{
		/// <summary>
		/// The channel type value.
		/// </summary>
		private ChannelType m_ChannelTypeValue;

        private bool m_Active;

        public bool Active
        {
            get
            {
                return m_Active;
            }

            set
            {
                m_Active = value;
            }
        }

        // Fires when the data is updated with the most recent data as the payload
        public event EventHandler<FaderEventArg<ChannelType>> DataChangedHandler;
		
		/// <summary>
		/// Returns the current system value of the data.
		/// </summary>
		/// <remarks>
		/// In the default implementation of the data-binder this is called every frame (in Update) so it's best to keep
		/// this implementation light weight.
		/// </remarks>
		abstract public ChannelType GetCurrentData();
		
		/// <summary>
		/// Set the current system value of the data.
		/// </summary>
		abstract protected void setDataModel(ChannelType value);
		
		// Grab the inital value for GetCurrentData
		virtual protected void Start() {
			m_ChannelTypeValue = GetCurrentData();
		}
		
		// Checks for change in data.
		// We need this in addition to SetCurrentData as the data we're linked to 
		// could be modified by an external source.
		void Update() {
			ChannelType currentData = GetCurrentData();
			if (!compare (m_ChannelTypeValue, currentData)) {
				fireDataChangedEvent (currentData);
			}
			m_ChannelTypeValue = currentData;
		}
		
		// Fire the data changed event. 
		// Wrapping this in a function allows child classes to call it and fire the event.
		protected void fireDataChangedEvent(ChannelType currentData) {
			EventHandler<FaderEventArg<ChannelType>> handler = DataChangedHandler;
			if ( handler != null ) { handler(this, new FaderEventArg<ChannelType>(currentData)); }
		}
		
		// Handles proper comparison of generic types.
		private bool compare(ChannelType x, ChannelType y)
		{
			return EqualityComparer<ChannelType>.Default.Equals(x, y);
		}
	}

	public abstract class FaderChannelTwitter : FaderChannel<TwitterChannelBase> {};
}