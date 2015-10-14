using UnityEngine;
using System;
using System.Collections;

namespace Fader {
  public class FaderEventArg<T> : EventArgs {
    private T m_currentValue;
    public T CurrentValue { get { return m_currentValue; } } 
  	public FaderEventArg ( T currentValue ) { 
      m_currentValue = currentValue;
    }
  }
}