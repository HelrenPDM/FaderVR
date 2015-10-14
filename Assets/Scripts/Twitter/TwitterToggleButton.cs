using UnityEngine;
using System.Collections;
using LMWidgets;

namespace Fader
{
    public class TwitterToggleButton : MonoBehaviour
    {

        public ButtonDemoToggle ToggleButton;
        public FaderChannel<TwitterChannelBase> m_TwitterChannel;

        // Use this for initialization
        void Start()
        {
            m_TwitterChannel = GetComponent<FaderChannel<TwitterChannelBase>>();
            ToggleButton.StartHandler += OnSimpleButtonAction;
        }

        private void OnSimpleButtonAction(object sender, LMWidgets.EventArg<bool> arg)
        {
            Debug.Log(this.transform.name + " pressed.");
            m_TwitterChannel.Active = !m_TwitterChannel.Active;
        }
    }
}
