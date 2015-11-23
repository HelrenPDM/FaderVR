using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using MiniJSON;

namespace Fader
{
    public class SpreadSheetReader : MonoBehaviour
    {

        // Use this for initialization
        void Start ()
        {

        }

        // Update is called once per frame
        void Update ()
        {

        }

        // Use of MINI JSON http://forum.unity3d.com/threads/35484-MiniJSON-script-for-parsing-JSON-data
        private List<SpreadSheetColumn> ParseResultsFromSpreadSheet (string jsonResults)
        {
            Debug.Log (jsonResults);
            List<SpreadSheetColumn> sheetDataList = new List<SpreadSheetColumn> ();

            foreach (var entry in sheetDataList)
            {
                Debug.Log (entry.ColumnHeader);
            }

            IDictionary search = (IDictionary)Json.Deserialize (jsonResults);
            IList years = (IList)search ["yearbook_item"];
            foreach (IDictionary year in years)
            {
                SpreadSheetColumn columnBase = new SpreadSheetColumn (year, SpreadSheet.CellType.);
                columnBase.TweetID = (Int64)tweet ["id"];
                columnBase.ScreenName = userInfo ["screen_name"] as string;
                columnBase.CreationDate = DateTime.ParseExact (tweet ["created_at"] as string, Const_TwitterDateTemplate, new System.Globalization.CultureInfo ("en-US"));
                columnBase.TweetText = tweet ["text"] as string;
                columnBase.RetweetCount = (Int64)tweet ["retweet_count"];
                columnBase.ProfileImageUrl = userInfo ["profile_image_url"] as string;

                sheetDataList.Add (columnBase);
            }

            return sheetDataList;
        }
    }
}

