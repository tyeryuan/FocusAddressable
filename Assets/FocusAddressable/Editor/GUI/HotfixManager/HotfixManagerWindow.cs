using FocusAddressable.Editor.GUI.Utility;
using FocusAddressable.Runtime.Core;
using FocusAddressable.Runtime.Core.Utility;
using FocusAddressable.Runtime.Core.Config;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FocusAddressable.Editor.GUI
{
    public class HotfixManagerWindow
    {
        public static void OnGUI()
        {
            EditorGUI.BeginChangeCheck();
            var oriColor = UnityEngine.GUI.color;
            if (string.IsNullOrEmpty(ConfigData.CheckOrGetConfigData().RemoteURL))
            {
                UnityEngine.GUI.color = Color.red;
            }
            GUIUtilityEx.DrawHorizontalItem("热更新地址", 100f, () =>
            {
                ConfigData.CheckOrGetConfigData().RemoteURL = EditorGUILayout.TextField(ConfigData.CheckOrGetConfigData().RemoteURL);
            });
            UnityEngine.GUI.color = oriColor;

            EditorGUI.BeginDisabledGroup(true);
            GUIUtilityEx.DrawHorizontalItem("热更新信息地址", 100f, () =>
            {
                var hotfixURL = string.Empty.BuildStrings("{热更新地址}/",Setting.PlatformName, "/{资源识别码}/", Setting.RemoteHotfixBuildInfoFileName);
                EditorGUILayout.TextField(hotfixURL);
            });
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(true);
            GUIUtilityEx.DrawHorizontalItem("热更新资源地址", 100f, () =>
            {
                var hotfixFolder = string.Empty.BuildStrings("{热更新地址}/", Setting.PlatformName, "/{资源识别码}/{热更新构建号}");
                EditorGUILayout.TextField(hotfixFolder);
            });
            EditorGUI.EndDisabledGroup();

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(ConfigData.CheckOrGetConfigData());
            }
        }
    }
}