//
// TwitterBase.cs
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
using System.Collections;
using UnityEngine;
using System;

namespace Fader
{
    public class TwitterBase
    {
        private long m_TweetID = 0;
        private string m_ScreenName = "";
        private DateTime m_CreationDate = DateTime.Now;
        private string m_TweetText = "";
        private string m_ProfileImageUrl = "";
        private long m_RetweetCount = 0;
        
        public long TweetID
        {
            get
            {
                return m_TweetID;
            }

            set
            {
                m_TweetID = value;
            }
        }

        public string ScreenName
        {
            get
            {
                return m_ScreenName;
            }

            set
            {
                m_ScreenName = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return m_CreationDate;
            }

            set
            {
                m_CreationDate = value;
            }
        }

        public string TweetText
        {
            get
            {
                return m_TweetText;
            }

            set
            {
                m_TweetText = value;
            }
        }

        public string ProfileImageUrl
        {
            get
            {
                return m_ProfileImageUrl;
            }

            set
            {
                m_ProfileImageUrl = value;
            }
        }

        public long RetweetCount
        {
            get
            {
                return m_RetweetCount;
            }

            set
            {
                m_RetweetCount = value;
            }
        }
    }
}
