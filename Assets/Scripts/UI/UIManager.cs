using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance = null;

    private List<UIData> uiList = null;//存放UI的栈，先进后出
    private Dictionary<string, GameObject> uiDict = null;//存放UI的GamoObject，无序

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        uiList = new List<UIData>();
        uiDict = new Dictionary<string, GameObject>();
        //OpenUI(UIPrefabData.UIMain);
    }

    //向后打开UI，从list取，若没有则实例化
    public void OpenUI(UIData UIObject, object param = null)
    {
        BaseUI uiNewGoScript = null;
        int uiListCount = uiList.Count;

        if (uiListCount > 0)
        {
            uiNewGoScript = OpenUIBySort(UIObject, uiList[uiListCount - 1]);
        }
        else
        {
            uiNewGoScript = OpenUIBySort(UIObject);
        }
        if (uiNewGoScript != null)
        {
            uiNewGoScript.UpdateData(param);
        }

        uiList.Add(UIObject);//入栈
    }

    //向前打开UI
    public void CloseUI()
    {
        int uiListCount = uiList.Count;
        if(uiListCount <= 0)
        {
            return;
        }

        BaseUI uiNextGoScript = null;
        UIData uiNowGoData = uiList[uiListCount - 1];
        UIData uiNextGoData = uiListCount > 1 ? uiList[uiListCount - 2] : null;

        uiNextGoScript = OpenUIBySort(uiNextGoData, uiNowGoData);

        if (uiNextGoScript != null)
        {
            //uiNewGoScript.UpdateData(param);
        }

        uiList.RemoveAt(uiListCount - 1);//出栈
    }

    //可向前或向后打开UI界面，如果没有前一个界面，则默认为null
    private BaseUI OpenUIBySort(UIData nextUIData,UIData lastUIData = null)
    {
        if(nextUIData == null)
        {
            return null;
        }

        GameObject lastUIGo = null;
        GameObject nextUIGo = null;
        BaseUI lastUIScript = null;
        BaseUI nextUIScript = null;

        if (lastUIData != null)
        {
            if (uiDict.TryGetValue(lastUIData.uiName, out lastUIGo))
            {
                if (lastUIData.componentName != string.Empty)
                {
                    lastUIScript = GetOrAddUIScript(lastUIData.componentName, lastUIGo);
                    lastUIScript.Close();
                }
            }
            else
            {
                return null;
            }
        }

        if (!uiDict.TryGetValue(nextUIData.uiName, out nextUIGo))
        {
            GameObject uiGoPrefab = Resources.Load(nextUIData.prefabPath) as GameObject;
            if (uiGoPrefab == null)
            {
                return null;
            }
            nextUIGo = Instantiate(uiGoPrefab) as GameObject;
            nextUIGo.name = nextUIData.uiName;
            nextUIGo.SetActive(true);
            uiDict.Add(nextUIData.uiName, nextUIGo);
        }

        if (nextUIData.componentName != string.Empty)
        {
            nextUIScript = GetOrAddUIScript(nextUIData.componentName, nextUIGo);
        }
        if (nextUIScript != null)
        {
            nextUIScript.Open(nextUIData.uiMode);
        }
        return nextUIScript;
    }

    //获取UI的脚本，如果没有则添加
    private BaseUI GetOrAddUIScript(string scriptName, GameObject uiGo)
    {
        BaseUI uiGoScript = uiGo.GetComponent(System.Type.GetType(scriptName)) as BaseUI;
        if (uiGoScript == null)
        {
            uiGoScript = uiGo.AddComponent(System.Type.GetType(scriptName)) as BaseUI;
        }
        return uiGoScript;
    }
}
