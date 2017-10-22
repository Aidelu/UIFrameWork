using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIMode
{
    AllScreen = 1,
    HalfSceenWithoutBtn,
    HalfSceenWithBtn,
}

//千万不要继承MonoBehaviour，否则base为null，不可用于类和null的比较
public class UIData
{

    public string uiName = string.Empty;
    public string prefabPath = string.Empty;
    public string componentName = string.Empty;
    public UIMode uiMode = UIMode.HalfSceenWithBtn;

    public UIData(string uname, string path, UIMode umode)
    {
        uiName = uname;
        prefabPath = path;
        uiMode = umode;
    }

    public UIData(string uname, string path, string cname,UIMode umode)
    {
        uiName = uname;
        prefabPath = path;
        componentName = cname;
        uiMode = umode;
    }
}
