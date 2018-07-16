using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mapbox.Unity
{
    public class DataPlotter : MonoBehaviour
    {

        public string inputfile;

        public GameObject PointPrefab;
        public GameObject CubePrefab;
        public GameObject CubeHolder;
        

        public int blockIDCol = 0;
        public int longitude1Col = 1;
        public int latitude1Col = 2;
        public int height1Col = 3;
        public int longitude2Col = 4;
        public int latitude2Col = 5;
        public int height2Col = 6;

        public string blockID;
        public string longitude1;
        public string latitude1;
        public string height1;
        public string longitude2;
        public string latitude2;
        public string height2;

        private float locationX;
        private float locationZ;
        private Map.AbstractMap _map;
        
        private List<GameObject> generatedCubes = new List<GameObject>();
        private List<Dictionary<string, object>> pointList;

        private List<Block> blocks = new List<Block>();

        // Use this for initialization
        void Start()
        {
            _map = FindObjectOfType<Map.AbstractMap>();
            pointList = CSVReader.Read(inputfile);

            Debug.Log(pointList);

            List<string> columnList = new List<string>(pointList[3].Keys);
            Debug.Log("There are " + columnList.Count + " columns");

            blockID = columnList[blockIDCol];

            longitude1 = columnList[longitude1Col];
            latitude1 = columnList[latitude1Col];
            height1 = columnList[height1Col];

            //longitude2 = columnList[longitude2Col];
            //latitude2 = columnList[latitude2Col];
            //height2 = columnList[height2Col];

            //for(var i = 0; i < pointList.Count; i++)
            //{
            //    Block newBlock = new Block();
                
            //}
            //GenerateAllCubes();
            GenerateAllPoints();
            

        }
    

        // Update is called once per frame
        void Update()
        {

        }

        //void GenerateAllCubes()
        //{
        //    //Loop through Pointlist
        //    for (var i = 0; i < pointList.Count; i++)
        //    {
        //        locationZ = i / 12;
        //        locationX = i % 12;
        //        // Get value in poinList at ith "row", in "column" Name
        //        float height = System.Convert.ToSingle(pointList[i][yName]);
        //        //float y = System.Convert.ToSingle(pointList[i][yName]);
        //        //float z = System.Convert.ToSingle(pointList[i][zName]);

        //        //instantiate the prefab with coordinates defined above
        //        GameObject rectangle = Instantiate(CubePrefab, new Vector3(locationX, 0, locationZ), Quaternion.identity);
        //        rectangle.transform.localScale = new Vector3(1, height, 1);
        //        rectangle.transform.localPosition += new Vector3(0, height / 2, 0);
        //        rectangle.transform.parent = CubeHolder.transform;
        //        rectangle.name = System.Convert.ToString(pointList[i][longitude1]);
        //        generatedCubes.Add(rectangle);
        //    }
        //}

        void GenerateAllPoints()

        {
            for (var i = 0; i < pointList.Count; i++)
            {
                float longitude = System.Convert.ToSingle(pointList[i][longitude1]);
                float latitude = System.Convert.ToSingle(pointList[i][latitude1]);
                Utils.Vector2d convertedVec = Utilities.Conversions.
                    GeoToWorldPosition(latitude, longitude, _map.CenterMercator, _map.WorldRelativeScale);
                GameObject sphere = Instantiate(PointPrefab, new Vector3((float)convertedVec.x, 0, (float)convertedVec.y),
                    Quaternion.identity);
                sphere.name = System.Convert.ToString(pointList[i][blockID]);
                sphere.transform.parent = GameObject.Find("DataPlotter").transform;
                sphere.GetComponent<Mapbox.Examples.LabelTextSetter>().SetText(sphere.name);
                sphere.GetComponent<Mapbox.Examples.LabelTextSetter>().HideText();

                //sphere.SetActive(false);
                sphere.GetComponent<Renderer>().material.color =
             Color.red;

            }
            
        }


        void DestroyAllCubes()
        {
            foreach (GameObject cube in generatedCubes)
            {

            }
        }

        struct Block
        {
            int blockID;

            float[] latitude;
            float[] longitude; 


        }

    }
}
