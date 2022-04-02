using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FocusAddressable.Editor.Core.Build
{
    [Serializable]
    public class BuildRules
    {
        public string Path = string.Empty;
        public string Filter = "*.*";
        public string ExcludeFilter = "*.meta";
        public int LabelIndex = 0;
        public List<string> FileList = new List<string>();

        //上次筛选的类型，可能会改变，改变后需要重新load
        private string _LastFilterStr = string.Empty;
        private string _LastExcludeFilterStr = string.Empty;

        public List<string> GetFileList(bool forceRefresh = false)
        {
            if (forceRefresh || FileList.Count == 0 || _LastFilterStr != Filter || _LastExcludeFilterStr != ExcludeFilter)
            {
                var fileList = AssetDatabase.FindAssets("", new string[] { Path });
                FileList.Clear();
                List<string> filterExtensions = new List<string>();
                filterExtensions.AddRange(Filter.Split('|'));
                List<string> excludeFilterExtensions = new List<string>();
                excludeFilterExtensions.AddRange(ExcludeFilter.Split('|'));
                for (int i = 0; i < fileList.Length; i++)
                {
                    var filePath = AssetDatabase.GUIDToAssetPath(fileList[i]);
                    var extension = "*" + System.IO.Path.GetExtension(filePath);
                    if (extension == "*")
                    {
                        continue;
                    }
                    if (Filter != "*.*" && filterExtensions.Contains(extension))
                    {
                        FileList.Add(filePath);
                        continue;
                    }
                    if (Filter == "*.*" && !excludeFilterExtensions.Contains(extension))
                    {
                        FileList.Add(filePath);
                        continue;
                    }
                }
                _LastFilterStr = Filter;
                _LastExcludeFilterStr = ExcludeFilter;
            }
            return FileList;
        }
    }
}