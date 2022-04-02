using FocusAddressable.Editor.Core;
using FocusAddressable.Editor.Core.Utility;
using FocusAddressable.Editor.GUI.Utility;
using FocusAddressable.Runtime.Core.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FocusAddressable.Editor.GUI
{
    public class FocusAddressableWindow : EditorWindow
    {
        [MenuItem(EditorSetting.MainWindowMenuPath)]
        private static void ShowWnd()
        {
            var wnd = GetWindow<FocusAddressableWindow>();
            wnd.titleContent = new GUIContent(EditorSetting.MainWindowTitle);
            wnd.Show();
        }


        private bool CheckNeedInit()
        {
            return ConfigData.CheckOrGetConfigData() == null;
        }

        private void ShowInitGUI()
        {
            if (GUILayout.Button("初始化FocusAddressable"))
            {
                EditorSetting.InitSetting();
            }
        }

        private void ShowNormalGUI()
        {
            GUIUtilityEx.SpliteWindow(LayoutDirection.Horizontal, 150f, () =>
            {
                EditorConfigData.CheckOrGetEditorConfigData().MainWindow_LeftFuncsSelectedIndex = GUIUtilityEx.DrawMenus(LayoutDirection.Vertical,
                    EditorSetting.MainWindow_LeftFuncs,
                    EditorConfigData.CheckOrGetEditorConfigData().MainWindow_LeftFuncsSelectedIndex,
                    EditorSetting.LightBlueTex2D,
                    out bool changed);
            }, () =>
            {
                switch (EditorConfigData.CheckOrGetEditorConfigData().MainWindow_LeftFuncsSelectedIndex)
                {
                    case 0:
                        AssetManagerWindow.OnGUI();
                        break;
                    case 1:
                        HotfixManagerWindow.OnGUI();
                        break;
                    default:
                        break;
                }
            });
        }

        private void OnGUI()
        {
            if (CheckNeedInit())
            {
                //初始化界面的UI
                ShowInitGUI();
            }
            else
            {
                //已经初始化过
                ShowNormalGUI();
            }
        }


    }
}