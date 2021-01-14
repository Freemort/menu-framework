using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MutatronicMenu
{
    public class Sheet : MonoBehaviour, IMenuComponent
    {
        private List<ISheetable> sheetables;

        [SerializeField] private GameObject linePrefab;

        [SerializeField] private Transform container;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            UpdateSheet();
        }

        public void UpdateSheet()
        {
            GetLines();
            //ClearLines();
            //InstantiateLines();
        }

        private void GetLines()
        {
            DevTestPopulate();
        }

        private void ClearLines()
        {
            foreach (GameObject line in container)
            {
                Destroy(line);
            }
            sheetables.Clear();
        }

        private void InstantiateLines()
        {
            foreach (ISheetable sheetable in sheetables)
            {
                GameObject.Instantiate(linePrefab, container);
            }
        }

        private void DevTestPopulate()
        {
            sheetables = new List<ISheetable>();

            sheetables.Add(new SomeClass()
            {
                name = "Name1",
                price = 10,
                time = DateTime.Now
            });

            sheetables.Add(new SomeClass()
            {
                name = "Name2",
                price = 20,
                time = DateTime.Now
            });

            sheetables.Add(new SomeClass()
            {
                name = "Name3",
                price = 30,
                time = DateTime.Now
            });
        }
    }

    [System.Serializable]
    class SheetableFieldData
    {
        public string fieldName;
        public string displayName;
        [HideInInspector] public DataType dataType;

        public enum DataType 
        {
            Field,
            Property
        }
    }
}