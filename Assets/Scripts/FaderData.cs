using UnityEngine;
using System;
using System.Collections.Generic;

namespace Fader
{
    /// <summary>
    /// Interface to define an object that can be a data provider for a fader item.
    /// </summary>
    public abstract class FaderData<PayloadType> : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        private PayloadType m_TypeData;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<FaderEventArg<PayloadType>> DataChangedHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public PayloadType GetData();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        abstract protected void setDataModel(PayloadType value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetCurrentData(PayloadType value)
        {
            setDataModel(value);
            fireDataChangedEvent(GetData());
            m_TypeData = GetData();
        }

        /// <summary>
        /// 
        /// </summary>
        virtual protected void Awake()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        virtual protected void Start()
        {
            m_TypeData = GetData();
        }

        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            PayloadType currentData = GetData();
            if (!compare(m_TypeData, currentData))
            {
                fireDataChangedEvent(currentData);
            }
            m_TypeData = currentData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentData"></param>
        protected void fireDataChangedEvent(PayloadType currentData)
        {
            EventHandler<FaderEventArg<PayloadType>> handler = DataChangedHandler;
            if (handler != null)
            {
                handler(this, new FaderEventArg<PayloadType>(currentData));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool compare(PayloadType x, PayloadType y)
        {
            return EqualityComparer<PayloadType>.Default.Equals(x, y);
        }

        abstract public string GetItemID();
        abstract public string GetItemAuthor();
        abstract public DateTime GetItemDateTime();
        abstract public string GetItemText();
    }
}
