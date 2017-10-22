using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//工具类
public class Utils : MonoBehaviour {

    //是否是可拾取物品
    public static bool isGetObject(GameObject obj)
    {
        if (obj.name == GlobalVar.ObjectName.coin || obj.name == GlobalVar.ObjectName.magnet || obj.name == GlobalVar.ObjectName.myCoinX2 ||
            obj.name == GlobalVar.ObjectName.protect || obj.name == GlobalVar.ObjectName.sprint)
        {
            return true;
        }
        return false;
    }

    //通过图集名获取图集
    public static UIAtlas GetAtlasByName(string altasName)
    {
        string path = PrefabsID.UIAltasPath + altasName;
        UIAtlas uiAtlas = Resources.Load(path, typeof(UIAtlas)) as UIAtlas;
        return uiAtlas;
    }
}
