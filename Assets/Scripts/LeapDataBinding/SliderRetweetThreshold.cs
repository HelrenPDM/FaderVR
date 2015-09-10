using UnityEngine;
using System;
using System.Collections;
using LMWidgets;

namespace Fader
{
    public class SliderRetweetThreshold : DataBinderSlider
    {
        public FaderChannel<TwitterChannelBase> m_TwitterChannel;

        override protected void setDataModel(float value)
        {

        }

        override public float GetCurrentData()
        {
            return Convert.ToSingle(m_TwitterChannel.GetCurrentData().RetweetThreshold);
        }
    }
}