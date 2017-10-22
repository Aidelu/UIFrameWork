using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemUI : MonoBehaviour
{

    protected Dictionary<string, GameObject> goDict = null;
    protected readonly string BTN_NAME = "Btn";

    void Awake()
    {
        DoAwake();
    }
    void Start()
    {
        DoStart();
    }
    void Update()
    {
        DoUpdate();
    }

    protected virtual void DoAwake()
    {
        goDict = new Dictionary<string, GameObject>();
        initGoDict();
    }
    protected virtual void DoStart()
    {

    }
    protected virtual void DoUpdate()
    {

    }

    void initGoDict()
    {
        addGoDict(this.transform);
    }

    void addGoDict(Transform root)
    {
        foreach (Transform childGo in root)
        {
            if (childGo != null)
            {
                goDict.Add(childGo.name, childGo.gameObject);
                if (childGo.name.EndsWith(BTN_NAME))
                {
                    UIEventListener.Get(childGo.gameObject).onClick = NguiOnClick;
                }
                addGoDict(childGo);
            }
        }
    }


    protected virtual void NguiOnClick(GameObject go)
    {
        //print(go.name);
       
    }

    public virtual void UpdateData(BaseInfo info)
    {

    }
}
