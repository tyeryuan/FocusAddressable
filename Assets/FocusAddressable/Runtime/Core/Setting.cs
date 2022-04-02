using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FocusAddressable.Runtime.Core
{
    public class Setting
    {
        /// <summary>
        /// 远程热更资源的构建信息文件名
        /// </summary>
        public const string RemoteHotfixBuildInfoFileName = "HotfixBuildInfo.txt";

#if UNITY_ANDROID
        public const string PlatformName = "Android";
#elif UNITY_IOS
        public const string PlatformName = "iOS";
#else
        public const string PlatformName = "Unknown";
#endif
        
    }
}