using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MutatronicMenu
{
    public class SomeClassWrapper
    {
        public Type type;

        public List<SheetHeading> sheetHeadings = new List<SheetHeading>()
        {
            new SheetHeading()
            {
                displayName = "SomeName1",
                GetValue = (someClass) => ((SomeClass)someClass).name
            }
        };

        private string GetSomeVal() 
        {
            SomeClass some = new SomeClass();
            SheetHeading heading = new SheetHeading();
            return heading.GetValue(some);
        }
    }

    public class SheetHeading
    {
        public string displayName;
        public Func<object, string> GetValue;
    }
}