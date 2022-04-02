using FocusAddressable.Editor.Core;
using FocusAddressable.Editor.Core.Build;
using FocusAddressable.Editor.Core.Utility;
using FocusAddressable.Editor.GUI.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace FocusAddressable.Editor.GUI
{
    public class AssetsFilterRuleWindow
    {
        private static ReorderableList reorderableList = null;

        public static void OnGUI()
        {
            if (reorderableList == null)
            {
                reorderableList = new ReorderableList(EditorConfigData.CheckOrGetEditorConfigData().BuildRules, typeof(BuildRules))
                {
                    elementHeight = EditorGUIUtility.singleLineHeight * 1.5f,
                    drawHeaderCallback = DrawHeader,
                    drawElementCallback = DrawElement
                };
            }

            reorderableList.DoLayoutList();
        }

        private static void DrawHeader(Rect rect)
        {
            float startX = rect.x;
            EditorGUI.LabelField(new Rect(rect.x + 50f, rect.y, 200f, EditorGUIUtility.singleLineHeight),EditorSetting.BuildRule_Title_1);
            startX += 200f + 10f;
            startX += 90f + 50f;
            EditorGUI.LabelField(new Rect(startX, rect.y, 100f, EditorGUIUtility.singleLineHeight), EditorSetting.BuildRule_Title_2);
            
            if (EditorGUI.DropdownButton(new Rect(startX + 30f, rect.y, 20, EditorGUIUtility.singleLineHeight), new GUIContent("!"), FocusType.Passive, EditorStyles.miniButton))
            {
                EditorUtility.DisplayDialog(EditorSetting.Dialog_Title_Tip, EditorSetting.Dialog_Description_Label, EditorSetting.Dialog_Button_OK);
            }

            startX += 50f + 50f;
            EditorGUI.LabelField(new Rect(startX, rect.y, 100f, EditorGUIUtility.singleLineHeight), EditorSetting.BuildRule_Title_3);
        }

        private static void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            EditorGUI.BeginChangeCheck();
            float startX = rect.x;
            var itemInfo = EditorConfigData.CheckOrGetEditorConfigData().BuildRules[index];
            EditorGUI.LabelField(new Rect(startX, rect.y, 200f, EditorGUIUtility.singleLineHeight), itemInfo.Path);

            startX += 200f + 10f;
            if (EditorGUI.DropdownButton(new Rect(rect.x + 200f+ 50f, rect.y + 3f, 40f, EditorGUIUtility.singleLineHeight),
                new GUIContent(EditorSetting.BuildRule_ChangePath_Label), FocusType.Passive,EditorStyles.toolbarButton))
            {
                var path = EditorUtility.OpenFolderPanel(EditorSetting.ChooleAssetFolderDialog_Title, string.IsNullOrEmpty(itemInfo.Path) ? Application.dataPath : itemInfo.Path, 
                    string.Empty);
                if (Directory.Exists(path))
                {
                    itemInfo.Path = FileUtil.GetProjectRelativePath(path);
                    EditorUtility.SetDirty(EditorConfigData.CheckOrGetEditorConfigData());
                }
            }

            startX += 90f + 10f;
            EditorGUI.DrawRect(new Rect(startX-5f, rect.y- EditorGUIUtility.singleLineHeight, 1f, EditorGUIUtility.singleLineHeight*2.5f), Color.black);
            itemInfo.LabelIndex = EditorGUI.Popup(new Rect(startX, rect.y + 4f, 90f, EditorGUIUtility.singleLineHeight), itemInfo.LabelIndex, EditorConfigData.CheckOrGetEditorConfigData().LabelList.ToArray());

            startX += 90f + 10f;
            EditorGUI.DrawRect(new Rect(startX - 5f, rect.y - EditorGUIUtility.singleLineHeight, 1f, EditorGUIUtility.singleLineHeight * 2.5f), Color.black);
            EditorGUI.LabelField(new Rect(startX, rect.y + 3f, 100f, EditorGUIUtility.singleLineHeight), itemInfo.GetFileList().Count.ToString(), 
                new GUIStyle(EditorStyles.label) { alignment = TextAnchor.MiddleCenter });

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(EditorConfigData.CheckOrGetEditorConfigData());
            }
        }
    }
}