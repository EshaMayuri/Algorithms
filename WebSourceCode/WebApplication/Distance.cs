﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;

namespace WebApplication
{
    public sealed class Distance
    {
        //Hash map to store zipCodes accessible from a particular zipCode and distance between them.
        public Dictionary<string, List<ZipNodes>> graph = new Dictionary<string, List<ZipNodes>>();

        /// <summary>
        /// Class constructor
        /// </summary>
        private Distance() { }

        private static Distance instance = null;

        /// <summary>
        /// Singleton class instance
        /// </summary>
        public static Distance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Distance();
                }
                return instance;
            }
        }

        /// <summary>
        /// Function to fetch distance and reachable zipcodes data from Distance.xml document
        /// </summary>
        public Dictionary<string, List<ZipNodes>> FetchDistanceGraph()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList xmlNodeList;

            string path = AppDomain.CurrentDomain.BaseDirectory;

            FileStream fs = new FileStream(path + @"\Distance.xml", FileMode.Open, FileAccess.Read);
            xmlDoc.Load(fs);
            xmlNodeList = xmlDoc.GetElementsByTagName("Details");
            for (int n = 0; n <= 1; n++)
            {
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    xmlNodeList[i].ChildNodes.Item(0).InnerText.Trim();
                    string zipCode = xmlNodeList[i].ChildNodes.Item(n).InnerText.Trim().ToString();
                    BuildGraphNodes(zipCode);
                }
            }

            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                xmlNodeList[i].ChildNodes.Item(0).InnerText.Trim();
                string zipCode1 = xmlNodeList[i].ChildNodes.Item(0).InnerText.Trim().ToString();
                string zipCode2 = xmlNodeList[i].ChildNodes.Item(1).InnerText.Trim().ToString();
                int distance = int.Parse(xmlNodeList[i].ChildNodes.Item(2).InnerText.Trim());
                BuildGraphEdges(zipCode1, zipCode2, distance);
            }

            fs.Close();
            return graph;
        }

        /// <summary>
        /// Function to build graph of zipcodes
        /// </summary>
        /// <param name="zipCode"></param>
        private void BuildGraphNodes(string zipCode)
        {
            if (!graph.ContainsKey(zipCode))
            {
                graph.Add(zipCode, new List<ZipNodes>());
            }
        }

        /// <summary>
        /// Function to build graph of edges between the zipcodes.
        /// </summary>
        /// <param name="zipCode1"></param>
        /// <param name="zipCode2"></param>
        /// <param name="distance">distance between zipcode1 and zipcode2</param>
        private void BuildGraphEdges(string zipCode1, string zipCode2, int distance)
        {
            ZipNodes zipNode1 = new ZipNodes(zipCode2, distance);
            ZipNodes zipNode2 = new ZipNodes(zipCode1, distance);

            if (!graph[zipCode1].Contains(zipNode1))
            {
                graph[zipCode1].Add(zipNode1);
            }
            if (!graph[zipCode2].Contains(zipNode2))
            {
                graph[zipCode2].Add(zipNode2);
            }
        }
    }
}