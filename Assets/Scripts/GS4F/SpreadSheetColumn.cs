//
// SpreadSheetColumn.cs
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
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Fader
{
    [Serializable]
    public abstract class SpreadSheetColumn<PayloadType>
	{
        public string ColumnHeader;

        /// <summary>
        /// 
        /// </summary>
        public PayloadType m_TypeData;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<FaderEventArg<PayloadType>> DataChangedHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public PayloadType GetData ();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        abstract protected void setDataModel (PayloadType value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetCurrentData (PayloadType value)
        {
            setDataModel (value);
            fireDataChangedEvent (GetData ());
            m_TypeData = GetData ();
        }

        /// <summary>
        /// 
        /// </summary>
        virtual protected void Awake ()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        virtual protected void Start ()
        {
            m_TypeData = GetData ();
        }

        /// <summary>
        /// 
        /// </summary>
        void Update ()
        {
            PayloadType currentData = GetData ();
            if (!compare (m_TypeData, currentData))
            {
                fireDataChangedEvent (currentData);
            }
            m_TypeData = currentData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentData"></param>
        protected void fireDataChangedEvent (PayloadType currentData)
        {
            EventHandler<FaderEventArg<PayloadType>> handler = DataChangedHandler;
            if (handler != null)
            {
                handler (this, new FaderEventArg<PayloadType> (currentData));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool compare (PayloadType x, PayloadType y)
        {
            return EqualityComparer<PayloadType>.Default.Equals (x, y);
        }
    }

    public class SpreadSheetColumnDateTime : SpreadSheetColumn<DateTime>
    {
        public override DateTime GetData ()
        {
            return GetData ();
        }

        protected override void setDataModel (DateTime value)
        {
            this.m_TypeData = value;
        }
    };

    public class SpreadSheetColumnString : SpreadSheetColumn<string>
    {
        public override string GetData ()
        {
            return GetData ();
        }

        protected override void setDataModel (string value)
        {
            this.m_TypeData = value;
        }
    }

    public class SpreadSheetColumnLong : SpreadSheetColumn<long>
    {
        public override long GetData ()
        {
            return GetData ();
        }

        protected override void setDataModel (long value)
        {
            this.m_TypeData = value;
        }
    }
}
