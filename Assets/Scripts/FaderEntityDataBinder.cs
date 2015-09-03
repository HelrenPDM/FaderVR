using UnityEngine;
using System;
using System.Collections.Generic;

namespace Fader {

	public abstract class FaderEntityDataBinder<PayloadType> : MonoBehaviour {

		/// <summary>
		/// The m_ children.
		/// </summary>
		[SerializeField]
		private List<FaderEntityDataBinder<PayloadType>> m_Children;
		/// <summary>
		/// The m_ parent.
		/// </summary>
		[SerializeField]
		private FaderEntityDataBinder<PayloadType> m_Parent;
		/// <summary>
		/// The m_ siblings.
		/// </summary>
		[SerializeField]
		private FaderEntityDataBinder<PayloadType> m_Siblings;

		/// <summary>
		/// The m_ data value.
		/// </summary>
		private PayloadType m_DataValue;

		// Fires when the data is updated with the most recent data as the payload
		public event EventHandler<FaderEventArg> DataChangedHandler;
		
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

	public abstract class FaderEntityDataBinderTwitter : FaderEntityDataBinder<TwitterData> {};
}
