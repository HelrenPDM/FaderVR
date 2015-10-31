//
// FaderEntityTwitter.cs
//
// Author:
//       Stephan Gensch <stgensch@vragments.com>
//
// Copyright (c) 2015 Stephan
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


using System;

namespace Fader
{
    public class FaderTwitterData : FaderData<TwitterDataBase>
    {
        private TwitterDataBase m_Data;

        public override TwitterDataBase GetData()
        {
            return m_Data;
        }

        public override string GetItemAuthor()
        {
            return m_Data.ScreenName;
        }

        public override DateTime GetItemDateTime()
        {
            return m_Data.CreationDate;
        }

        public override string GetItemID()
        {
            return m_Data.TweetID.ToString();
        }

        public override string GetItemText()
        {
            return m_Data.TweetText;
        }

        protected override void setDataModel(TwitterDataBase value)
        {
            if (value != null)
            {
                m_Data = value;
            }
        }
    }
}

