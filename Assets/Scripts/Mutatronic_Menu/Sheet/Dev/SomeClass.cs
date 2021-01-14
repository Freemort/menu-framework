using System;
using System.Collections.Generic;
using UnityEngine;

namespace MutatronicMenu
{
    public class SomeClass : ISheetable
    {
        [SheetableField("Название")]
        public string name;
        public float price;
        public DateTime time;

        [SheetableField("111")]
        public string Name { get; set; }
    }
}