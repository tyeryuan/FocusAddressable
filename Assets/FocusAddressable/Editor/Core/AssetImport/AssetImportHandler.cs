using FocusAddressable.Editor.Core.Build;
using FocusAddressable.Editor.Core.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FocusAddressable.Editor.Core
{
    public class AssetImportHandler : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            var affectedRuleList = new List<BuildRules>();
            for (int i = 0; i < EditorConfigData.CheckOrGetEditorConfigData().BuildRules.Count; i++)
            {
                var item = EditorConfigData.CheckOrGetEditorConfigData().BuildRules[i];

            }
            List<string> fileList = new List<string>();
            fileList.AddRange(importedAssets);
            fileList.AddRange(deletedAssets);
            fileList.AddRange(movedAssets);
            fileList.AddRange(movedFromAssetPaths);
            foreach (var path in fileList)
            {
                for (int i = 0; i < EditorConfigData.CheckOrGetEditorConfigData().BuildRules.Count; i++)
                {
                    var item = EditorConfigData.CheckOrGetEditorConfigData().BuildRules[i];
                    if (path.Contains(item.Path))
                    {
                        affectedRuleList.Add(item);
                    }
                }
            }

            for (int i = 0; i < affectedRuleList.Count; i++)
            {
                var item = affectedRuleList[i];
                item.GetFileList(true);
            }
        }
    }
}