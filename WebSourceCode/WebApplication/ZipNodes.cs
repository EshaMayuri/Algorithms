﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class ZipNodes
    {
        public string zipCode;
        public int distance;

        /// <summary>
        /// Setter and getter for zipcode
        /// </summary>
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                zipCode = value;
            }
        }

        /// <summary>
        /// Setter and getter for distance
        /// </summary>
        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }

        /// <summary>
        /// Class parameterized constructor
        /// </summary>
        /// <param name="zipCode"></param>
        /// <param name="distance"></param>
        public ZipNodes(string zipCode, int distance)
        {
            this.zipCode = zipCode;
            this.distance = distance;
        }
    }
}