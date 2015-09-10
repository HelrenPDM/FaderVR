//
// FaderEntityDataBinder.cs
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

namespace Fader {

	public abstract class FaderEntityDataBinder<PayloadType> : MonoBehaviour {

		/// <summary>
		/// The m_ children.
		/// </summary>
		private List<FaderEntityDataBinder<PayloadType>> m_Children;
		/// <summary>
		/// The m_ parent.
		/// </summary>
		private FaderEntityDataBinder<PayloadType> m_Parent;
		/// <summary>
		/// The m_ siblings.
		/// </summary>
		private List<FaderEntityDataBinder<PayloadType>> m_Siblings;

		/// <summary>
		/// The m_ data value.
		/// </summary>
		private PayloadType m_DataValue;

		// Fires when the data is updated with the most recent data as the payload
		public event EventHandler<FaderEventArg<PayloadType>> DataChangedHandler;
		
		/// <summary>
		/// Returns the current system value of the data.
		/// </summary>
		/// <remarks>
		/// In the default implementation of the data-binder this is called every frame (in Update) so it's best to keep
		/// this implementation light weight.
		/// </remarks>
		abstract public PayloadType GetCurrentData();
		
		/// <summary>
		/// Set the current system value of the data.
		/// </summary>
		abstract protected void setDataModel(PayloadType value);

		// Grab the inital value for GetCurrentData
		virtual protected void Start() {
			m_DataValue = GetCurrentData();
		}
		
		// Checks for change in data.
		// We need this in addition to SetCurrentData as the data we're linked to 
		// could be modified by an external source.
		void Update() {
			PayloadType currentData = GetCurrentData();
			if (!compare (m_DataValue, currentData)) {
				fireDataChangedEvent (currentData);
			}
			m_DataValue = currentData;
		}

		// Fire the data changed event. 
		// Wrapping this in a function allows child classes to call it and fire the event.
		protected void fireDataChangedEvent(PayloadType currentData) {
			EventHandler<FaderEventArg<PayloadType>> handler = DataChangedHandler;
			if ( handler != null ) { handler(this, new FaderEventArg<PayloadType>(currentData)); }
		}
		
		// Handles proper comparison of generic types.
		private bool compare(PayloadType x, PayloadType y)
		{
			return EqualityComparer<PayloadType>.Default.Equals(x, y);
		}
	}

	public abstract class FaderEntityDataBinderTwitter : FaderEntityDataBinder<TwitterBase> {};
}
