using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FocusAddressable.Editor.GUI.Utility
{
    internal enum LayoutDirection
    {
        Horizontal,
        Vertical
    }
    internal class GUIUtilityEx
    {
        public static void SpliteWindow(LayoutDirection direction, float part1Area, Action part1OnGUICallback, Action part2OnGUICallback)
        {
            switch (direction)
            {
                case LayoutDirection.Horizontal:
                    EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.BeginVertical(GUILayout.Width(part1Area));
                    part1OnGUICallback?.Invoke();
                    EditorGUILayout.EndVertical();

                    GUILayout.Box("", GUILayout.ExpandHeight(true), GUILayout.Width(1f));

                    EditorGUILayout.BeginVertical();
                    part2OnGUICallback?.Invoke();
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.EndHorizontal();
                    break;
                case LayoutDirection.Vertical:
                    EditorGUILayout.BeginVertical();

                    EditorGUILayout.BeginVertical(GUILayout.Height(part1Area));
                    part1OnGUICallback?.Invoke();
                    EditorGUILayout.EndVertical();

                    GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1f));

                    EditorGUILayout.BeginVertical();
                    part2OnGUICallback?.Invoke();
                    EditorGUILayout.EndVertical();

                    EditorGUILayout.EndVertical();
                    break;
            }
        }

        public static int DrawMenus(LayoutDirection direction, string[] funcNameArr, int selectedIndex,Texture2D selectedMenuTex, out bool chaned)
        {
            int newSelectedIndex = selectedIndex;
            switch (direction)
            {
                case LayoutDirection.Horizontal:
                    EditorGUILayout.BeginHorizontal();
                    for (int i = 0; i < funcNameArr.Length; i++)
                    {
                        var funcName = funcNameArr[i];
                        GUIStyle style = EditorStyles.toolbarButton;
                        if (selectedIndex == i)
                        {
                            style = new GUIStyle(style) { normal = new GUIStyleState() { background = selectedMenuTex, textColor = Color.white } };
                        }
                        if (GUILayout.Button(funcName, style))
                        {
                            newSelectedIndex = i;
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                    break;
                case LayoutDirection.Vertical:
                    EditorGUILayout.BeginVertical();
                    for (int i = 0; i < funcNameArr.Length; i++)
                    {
                        var funcName = funcNameArr[i];
                        GUIStyle style = EditorStyles.toolbarButton;
                        if (selectedIndex == i)
                        {
                            style = new GUIStyle(style) { normal = new GUIStyleState() { background = selectedMenuTex, textColor = Color.white } };
                        }
                        if (GUILayout.Button(funcName, style))
                        {
                            newSelectedIndex = i;
                        }
                    }
                    EditorGUILayout.EndVertical();
                    break;
            }
            
            chaned = newSelectedIndex != selectedIndex;
            return newSelectedIndex;
        }

        public static void DrawLayoutMargin(float leftMargin, float rightMargin, Action callback)
        {
            EditorGUILayout.BeginHorizontal();

            GUILayout.Space(leftMargin);

            EditorGUILayout.BeginVertical();
            callback?.Invoke();
            EditorGUILayout.EndVertical();

            GUILayout.Space(rightMargin);
            EditorGUILayout.EndHorizontal();
        }

        public static void DrawHorizontalItem(string label, float labelWidth, Action callback)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(label, GUILayout.Width(labelWidth));

            callback?.Invoke();

            EditorGUILayout.EndHorizontal();
        }
        
    }
}