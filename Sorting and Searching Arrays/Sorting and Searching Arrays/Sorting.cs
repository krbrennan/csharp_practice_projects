﻿using Sorting;
using System;


var names = new List<string> { "Bob", "Cindy", "Zach", "Nathan", "Abel" };
//var names = new List<string>(){ "Bob", "Cindy", "Zach", "Nathan", "Abel" };
var firstSort = new SortingNames(names);
Console.WriteLine($"Sorting names: {names}");
//firstSort
firstSort.AddNames(["Fanny", "Bertha"]);
Console.ReadLine();


namespace Sorting
{

    class SortingNames
    {
        private List<string> _names { get; set; }
        public SortingNames(List<string> names) {
            _names = names;
        }


        public List<string> ReadNames
        {
            get { return _names; }
        }

        public string AddNames(string[] names)
        {
            if(names.Length > 0)
            {
                //_names.Add(names);
                //return $"Names added: {names}";
                foreach (string name in names)
                {
                    _names.Add(name);
                }
            }
            return $"Names added!";
        }
    }

}





