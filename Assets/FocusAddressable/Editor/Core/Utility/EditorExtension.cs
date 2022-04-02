using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using FocusAddressable.Runtime.Core.Utility;

namespace FocusAddressable.Editor.Core.Utility
{
    public static class EditorExtension
    {
        /// <summary>
        /// 创建ScriptableObject类型的asset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringEmpty"></param>
        /// <param name="assetPath"></param>
        public static T CreateScriptableObjectAsset<T>(this string stringEmpty, string assetPath) where T : ScriptableObject
        {
            T t = ScriptableObject.CreateInstance<T>();
            string.Empty.CheckOrCreateFileOwnerFolder(assetPath);
            AssetDatabase.CreateAsset(t, assetPath);
            AssetDatabase.Refresh();
            return t;
        }
    }
}