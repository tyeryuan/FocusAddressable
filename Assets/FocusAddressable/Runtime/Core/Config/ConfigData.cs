using FocusAddressable.Runtime.Core.Utility;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FocusAddressable.Runtime.Core.Config
{
    public class ConfigData : ScriptableObject
    {
        /// <summary>
        /// 远程资源热更地址
        /// </summary>
        public string RemoteURL = string.Empty;

        /// <summary>
        /// 资源识别码，每次进行资源全部构建时会生成一个
        /// </summary>
        public string Identity = string.Empty;

        public string GetRemoteHotfixConfigInfoURL()
        {
            var url = Path.Combine(RemoteURL, string.Empty.BuildStrings(Setting.PlatformName, '/', Identity, Setting.RemoteHotfixBuildInfoFileName));
            return url;
        }

        private static ConfigData _ConfigData = null;

        public static ConfigData CheckOrGetConfigData()
        {
            if (_ConfigData == null)
            {
                _ConfigData = Resources.Load<ConfigData>(typeof(ConfigData).Name);
            }
            return _ConfigData;
        }

    }
}