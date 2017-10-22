using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//对象池
//Add：若物品已存在，则销毁，否则添加
//Get：根据所需的物品类型进行返回，若存在，则会返回并移除，若不存在，则实例化
public class PoolManager : MonoBehaviour {

    private List<GameObject> goPoolList = null;
    private int PoolMaxCount = 30;

    public PoolManager()
    {
        goPoolList = new List<GameObject>();
    }

    //获取对象数目
    public int getPoolCount()
    {
        return goPoolList.Count;
    }

    //添加对象
    public void addPoolGo(GameObject go)
    {
        if (goPoolList.Count <= PoolMaxCount)
        {
            goPoolList.Add(go);
            go.SetActive(false);
        }
        else
        {
            Destroy(go.gameObject);
        }
    }

    //返回对象
    public GameObject getPoolGo(string goPath)
    {
        GameObject go = null;

        go = createGo(goPath);
        if (go)
        {
            go.SetActive(true);
        }

        return go;
    }

    private GameObject createGo(string goPath)
    {
        string goName = goPath.Substring(goPath.LastIndexOf('/') + 1);
        GameObject go = null;

        if (ContainsName(goName))
        {
            go = getListGo(goName);
            goPoolList.Remove(go);
        }
        else
        {
            GameObject goPre = Resources.Load(goPath) as GameObject;
            if (goPre)
            {
                go = Instantiate(goPre) as GameObject;
                go.name = goName;
            }
        }

        return go;
    }

    private bool ContainsName(string goName)
    {
        for(int i=0;i<goPoolList.Count;i++)
        {
            if (goPoolList[i].name == goName)
            {
                return true;
            }
        }
        return false;
    }

    private GameObject getListGo(string goName)
    {
        for (int i = 0; i < goPoolList.Count; i++)
        {
            if (goPoolList[i].name == goName)
            {
                return goPoolList[i].gameObject;
            }
        }
        return null;
    }
}
