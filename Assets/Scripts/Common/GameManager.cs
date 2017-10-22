using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
    private int PandaId = 0;
    void Awake()
    {
        CreatePanda();
    }
    void Start()
    {
        CreateUI();
    }
    private void CreatePanda()
    {
        PandaId = PlayerInfo.PandaType;
        GameObject PandaPre = Resources.Load(PrefabsID.PandaPath + PandaId.ToString()) as GameObject;
        if (PandaPre)
        {
            GameObject Panda = Instantiate(PandaPre) as GameObject;
            Panda.transform.position = PandaInfo.startPos;
            Panda.name = GlobalVar.ObjectName.pandaName;
            Panda.AddComponent<PandaController>();
        }
    }

    private void CreateUI()
    {
        UIManager.Instance.OpenUI(UIPrefabData.UIGame);
    }
}
