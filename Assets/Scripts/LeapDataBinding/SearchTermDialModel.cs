using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LMWidgets;

namespace Fader
{
    public class SearchTermDialModel : DataBinderDial
    {

        public FaderChannel<TwitterChannelBase> m_TwitterChannel;

        override protected void setDataModel(string value)
        {

        }

        override public string GetCurrentData()
        {
            return "Child abuse";
        }
    }
}

