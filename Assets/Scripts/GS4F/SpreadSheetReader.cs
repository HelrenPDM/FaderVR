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
        private List<SpreadSheetColumnString> ParseResultsFromSpreadSheet (string jsonResults)
        {
            Debug.Log (jsonResults);
            List<SpreadSheetColumnString> sheetDataList = new List<SpreadSheetColumnString> ();

            foreach (var entry in sheetDataList)
            {
                Debug.Log (entry.ColumnHeader);
            }

            IDictionary search = (IDictionary)Json.Deserialize (jsonResults);
            IList years = (IList)search ["yearbook_item"];
            foreach (IDictionary year in years)
            {
                SpreadSheetColumnString columnBase = new SpreadSheetColumnString ();
                
                sheetDataList.Add (columnBase);
            }

            return sheetDataList;
        }
    }
}

