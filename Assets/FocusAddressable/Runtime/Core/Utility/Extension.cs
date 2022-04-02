using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace FocusAddressable.Runtime.Core.Utility
{
    public static class Extension
    {
        private static StringBuilder _builder = new StringBuilder();

        /// <summary>
        /// 构建拼接成字符串
        /// </summary>
        /// <param name="stringEmpty"></param>
        /// <param name="subStringsArr"></param>
        /// <returns></returns>
        public static string BuildStrings(this string stringEmpty, params object[] subStringsArr)
        {
            _builder.Clear();
            for (int i = 0; i < subStringsArr.Length; i++)
            {
                var sub = subStringsArr[i];
                _builder.Append(sub.ToString());
            }
            return _builder.ToString();
        }

        /// <summary>
        /// 检测并创建目录
        /// </summary>
        /// <param name="stringEmpty"></param>
        /// <param name="folderPath"></param>
        public static void CheckOrCreateFolder(this string stringEmpty, string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// 检测并创建文件所属目录
        /// </summary>
        /// <param name="stringEmpty"></param>
        /// <param name="filePath"></param>
        public static void CheckOrCreateFileOwnerFolder(this string stringEmpty, string filePath)
        {
            var fodler = Path.GetDirectoryName(filePath);
            fodler.CheckOrCreateFolder(fodler);
        }

    }
}