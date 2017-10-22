using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManger : MonoBehaviour {

    void Start()
    {
        CreateUI();
    }

    private void CreateUI()
    {
        UIManager.Instance.OpenUI(UIPrefabData.UIMain);
    }
}
