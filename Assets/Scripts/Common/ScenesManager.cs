using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//顺序添加和移除
public class ScenesManager : MonoBehaviour {

    private List<GameObject> goSceneList = null;

    public ScenesManager()
    {
        goSceneList = new List<GameObject>();
    }

    //获取对象数目
    public int getSceneCount()
    {
        return goSceneList.Count;
    }

    //添加对象
    public void addSceneGo(GameObject go)
    {
        goSceneList.Add(go);
    }

    //返回第一个对象
    public GameObject getSceneGo()
    {
        GameObject go = null;

        if (getSceneCount() >= 0)
        {
            go = goSceneList[0].gameObject;
        }

        return go;
    }

    //移除第一个对象
    public void removeGo()
    {
        goSceneList.RemoveAt(0);
    }
}
