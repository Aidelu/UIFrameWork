using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour {

    protected Dictionary<string,GameObject> goDict = null;
    protected readonly string BTN_NAME = "Btn";
    private GameObject CloseContainer = null;//关闭UI的内容

	void Awake()
    {
        DoAwake();
    }
	void Start ()
    {
		DoStart();
	}
	void Update () 
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

    public virtual void Open(object param1 = null, object param2 = null, object param3 = null)
    {
        if ((UIMode)param1 == UIMode.HalfSceenWithBtn)
        {
            addCloseBtn();
        }
        UpdateCloseUI();
    }

    public virtual void UpdateData(object data = null)
    {
        if(data == null)
        {
            return;
        }
    }

    public virtual void Close()
    {
        UpdateCloseUI(false);
    }

    void initGoDict()
    {
        addGoDict(this.transform);
        //CloseContainer = goDict["CloseContainer"];
        if (goDict.TryGetValue("CloseContainer", out CloseContainer))
        {
            CloseContainer = goDict["CloseContainer"];
        }
    }

    void addGoDict(Transform root)
    {
        foreach(Transform childGo in root)
        {
            if(childGo != null)
            {
                goDict.Add(childGo.name, childGo.gameObject);
                if(childGo.name.EndsWith(BTN_NAME))
                {
                    UIEventListener.Get(childGo.gameObject).onClick = NguiOnClick;
                }
                addGoDict(childGo);
            }
        }
    }

    private void UpdateCloseUI(bool isOpen = true)
    {
        if (CloseContainer != null)
        {
            CloseContainer.SetActive(isOpen);
        }
    }

    protected virtual void NguiOnClick(GameObject go)
    {
        //print(go.name);
        switch(go.name)
        {
            case "CloseBtn":
                UIManager.Instance.CloseUI();
                break;
        }
    }

    protected void addCloseBtn()
    {
        if(!goDict.ContainsKey("CloseBtn"))
        {
            GameObject closeBtnPre = Resources.Load(PrefabsID.CloseBtnPrefab) as GameObject;
            if(closeBtnPre != null)
            {
                GameObject closeBtn = Instantiate(closeBtnPre) as GameObject;

                UISprite closeBtnSpt = closeBtn.GetComponent<UISprite>();
                if (closeBtnSpt != null)
                {
                    closeBtnSpt.SetAnchor(goDict["Bg"], -32, -142, 132, 20);
                    closeBtnSpt.leftAnchor.relative = 0;
                    closeBtnSpt.rightAnchor.relative = 0;
                    closeBtnSpt.topAnchor.relative = 0;
                    closeBtnSpt.bottomAnchor.relative = 0;
                }

                closeBtn.transform.parent = CloseContainer.transform;
                closeBtn.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                closeBtn.name = "CloseBtn";

                UIButtonColor closeBtnTween = closeBtn.GetComponent<UIButtonColor>();
                if (closeBtnTween != null)
                {
                    closeBtnTween.tweenTarget = closeBtn.gameObject;
                }

                UIEventListener.Get(closeBtn).onClick = NguiOnClick;
                goDict.Add("CloseBtn", closeBtn);
            }
        }
    }
}
