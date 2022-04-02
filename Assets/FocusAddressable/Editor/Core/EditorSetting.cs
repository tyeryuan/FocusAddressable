using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FocusAddressable.Runtime.Core.Utility;
using FocusAddressable.Runtime.Core.Config;
using FocusAddressable.Editor.Core.Utility;

namespace FocusAddressable.Editor.Core
{
    public class EditorSetting
    {
        /// <summary>
        /// 插件目录
        /// </summary>
        public const string PluginFolder = "Assets/FocusAddressable";
        /// <summary>
        /// 默认的配置数据路径
        /// </summary>
        public static string DefaultConfigDataFilePath = string.Empty.BuildStrings(PluginFolder, "/Runtime/Resources/", typeof(ConfigData).Name, ".asset");
        public static string DefaultEditorConfigDataFilePath = string.Empty.BuildStrings(PluginFolder, "/Editor/Resources/", typeof(EditorConfigData).Name, ".asset");


        //窗口相关
        public const string MainWindowMenuPath = "Window/Asset Management/资源寻址";
        public const string MainWindowTitle = "资源寻址";
        public static string[] MainWindow_LeftFuncs = { "资源管理", "热更新管理" };

        public static string[] AssetManagerWindow_TopFuncs = { "资源列表", "筛选规则" };

        public static string BuildRule_Title_1 = "资源目录";
        public static string BuildRule_Title_2 = "标签";
        public static string BuildRule_Title_3 = "资产个数";


        public static string BuildRule_ChangePath_Label = "...";


        public static string ChooleAssetFolderDialog_Title = "选择资源所处目录";

        public static string Dialog_Title_Warning = "警告";
        public static string Dialog_Title_Tip = "提示";
        public static string Dialog_Button_OK = "确定";

        public static string Dialog_Description_Label = "除Default标签外，其他标签一致的资源会打进同一个bundle中";





        static Texture2D _LightBlueTex2D = null;
        public static Texture2D LightBlueTex2D
        {
            get
            {
                if (_LightBlueTex2D == null)
                {
                    _LightBlueTex2D = Resources.Load<Texture2D>("Images/LightBlueBg");
                }
                return _LightBlueTex2D;
            }
        }

        static Texture2D _GrayTex2D = null;
        public static Texture2D GrayTex2D
        {
            get
            {
                if (_GrayTex2D == null)
                {
                    _GrayTex2D = Resources.Load<Texture2D>("Images/GrayBg");
                }
                return _GrayTex2D;
            }
        }

        public static void InitSetting()
        {
            var configData = ConfigData.CheckOrGetConfigData();
            if (configData==null)
            {
                string.Empty.CreateScriptableObjectAsset<ConfigData>(EditorSetting.DefaultConfigDataFilePath);
            }
            EditorConfigData.CheckOrGetEditorConfigData();
        }
    }
}