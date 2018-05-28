using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Mapbox.Unity
{
    public class DataDisplayHelper : MonoBehaviour
    {
        private List<Dictionary<string, object>> pointList;
        public string inputFile;
        public Text infoText;
        private string time;
        private string occupancy;
        private string text; 

        // Use this for initialization
        void Start()
        {
            infoText = GameObject.Find("InfoText").GetComponent<Text>();
            inputFile = gameObject.name;
            //pointList = CSVReader.Read(inputFile);
            //List<string> columnList = new List<string>(pointList[0].Keys);
            //time = columnList[0];
            //occupancy = columnList[1];
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //private void OnMouseUpAsButton()
        //{
        //    for (var i = 0; i < 5; i++)
        //    {
        //        text += System.Convert.ToString(pointList[i][occupancy]) + "\n";
        //    }
        //    infoText.text = text;

        //}
    }

}
