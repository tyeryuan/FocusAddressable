using FocusAddressable.Editor.Core;
using FocusAddressable.Editor.Core.Utility;
using FocusAddressable.Editor.GUI.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace FocusAddressable.Editor.GUI
{
    public class AssetManagerWindow
    {
        public static void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorConfigData.CheckOrGetEditorConfigData().AssetManagerWindow_TopFuncsSelectedIndex = GUIUtilityEx.DrawMenus(LayoutDirection.Horizontal,
                EditorSetting.AssetManagerWindow_TopFuncs,
                EditorConfigData.CheckOrGetEditorConfigData().AssetManagerWindow_TopFuncsSelectedIndex
                , EditorSetting.GrayTex2D, out bool chaned);

            switch (EditorConfigData.CheckOrGetEditorConfigData().AssetManagerWindow_TopFuncsSelectedIndex)
            {
                case 0:
                    AssetsListWindow.OnGUI();
                    break;
                case 1:
                    AssetsFilterRuleWindow.OnGUI();
                    break;
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(EditorConfigData.CheckOrGetEditorConfigData());
            }

        }
    }
}