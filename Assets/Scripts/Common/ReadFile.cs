using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFile
{
    public static List<object> ReadCSV(string className, string fileName)
    {
        List<object> csvList = null;

        string path = "Csv/" + fileName + ".csv";
        string filePath = GetFilePath(path);

        List<string[]> strList = new List<string[]>();
        string[] rowText;
#if UNITY_EDITOR
        rowText = File.ReadAllText(filePath, System.Text.Encoding.Default).Split(new string[] { "\r\n" }, StringSplitOptions.None);
#elif UNITY_ANDROID  
        WWW www = new WWW(filePath);
        while (!www.isDone) { }
        string wText = System.Text.Encoding.Default.GetString(System.Text.Encoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, System.Text.Encoding.Default.GetBytes(www.text)));
        rowText = www.text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
#endif
        for (int i = 0; i < rowText.Length; i++)
        {
            string value = rowText[i];
            string[] array = value.Split(',');
            strList.Add(array);
        }
        //if (File.Exists(filePath))
        //{
        //    StreamReader srReadFile = new StreamReader(filePath, System.Text.Encoding.Default);
        //    while (!srReadFile.EndOfStream)
        //    {
        //        //检索出行  
        //        string value = srReadFile.ReadLine();
        //        string[] array = value.Split(',');
        //        strList.Add(array);
        //    }
        //    // 关闭读取流文件  
        //    srReadFile.Close();
        //}
        //else
        //{
        //    Debug.LogError(fileName + "文件不存在");
        //    return null;
        //}
        csvList = TurnToList(className, strList);
        return csvList;
    }

    public static List<object> TurnToList(string className, List<string[]> fileContent)
    {
        List<object> fileInfoList = new List<object>();

        Type classType = Type.GetType(className);//通过反射获取类型


        for (int i = 2; i < fileContent.Count; i++)
        {
            object obj = Activator.CreateInstance(classType);//通过获取的类型创建实例

            for (int j = 0; j < fileContent[i].Length; j++)
            {
                System.Reflection.PropertyInfo member = classType.GetProperty(fileContent[0][j]);//从配置表获取变量名,再根据变量名获取对应变量属性

                if (member != null)
                {
                    switch (fileContent[1][j])
                    {
                        case "int":
                            //Debug.Log(fileContent[i][j]);
                            member.SetValue(obj, int.Parse(fileContent[i][j]), null);//给int类型变量赋值
                            break;
                        case "string":
                            member.SetValue(obj, fileContent[i][j], null);//给string类型变量赋值
                            break;
                        default:
                            return null;
                    }
                }
            }
            
            fileInfoList.Add(obj);//每一行是一个对象，通过遍历每一行获取一个个对象
        }
        return fileInfoList;
    }

    public static string GetFilePath(string _str)
    {
        string path = "";
        //Debug.Log(Application.streamingAssetsPath);
#if UNITY_EDITOR
        path = Application.dataPath + "/StreamingAssets/" + _str;
#elif UNITY_ANDROID  
                path = "jar:file://" + Application.dataPath + "!/assets/"+ _str ;
#elif UNITY_IPHONE  
                path = Application.dataPath + "/Raw/" + _str;
#endif
        return path;
    }

    public static string aaa()
    {
        return System.Text.Encoding.Default.ToString();
    }
}
