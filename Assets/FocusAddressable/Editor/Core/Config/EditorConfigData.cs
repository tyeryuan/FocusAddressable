using FocusAddressable.Editor.Core.Build;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FocusAddressable.Editor.Core.Utility
{
    public class EditorConfigData : ScriptableObject
    {

        public int MainWindow_LeftFuncsSelectedIndex = 0;
        public int AssetManagerWindow_TopFuncsSelectedIndex = 0;
        public List<BuildRules> BuildRules = new List<BuildRules>();
        public List<string> LabelList = new List<string>();


        private static EditorConfigData _ConfigData = null;

        public static EditorConfigData CheckOrGetEditorConfigData()
        {
            if (_ConfigData == null)
            {
                _ConfigData = Resources.Load<EditorConfigData>(typeof(EditorConfigData).Name);
                if (_ConfigData == null)
                {
                    _ConfigData = string.Empty.CreateScriptableObjectAsset<EditorConfigData>(EditorSetting.DefaultEditorConfigDataFilePath);
                }
            }
            if (_ConfigData.LabelList.Count == 0)
            {
                _ConfigData.LabelList.Add("Default");
            }
            return _ConfigData;
        }
    }
}