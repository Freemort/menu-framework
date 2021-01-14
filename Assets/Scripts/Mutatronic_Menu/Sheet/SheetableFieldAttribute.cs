using System;
using System.Collections.Generic;

namespace MutatronicMenu
{
    public class SheetableFieldAttribute : Attribute
    {
        public string FieldDisplayName { get; set; }
        public SheetableFieldAttribute(string fieldDisplayName)
        {
            FieldDisplayName = fieldDisplayName;
        }
    }
}