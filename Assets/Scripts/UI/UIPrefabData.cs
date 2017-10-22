using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrefabData
{
    public static UIData UIMain = new UIData("UIMAIN", PrefabsID.UIMainPath, "UIMain", UIMode.AllScreen);
    public static UIData UITask = new UIData("UITASK", PrefabsID.UITaskPath, "UITask", UIMode.HalfSceenWithBtn);
    public static UIData UIOption = new UIData("UIOPTION", PrefabsID.UIOptionPath, "UIOption", UIMode.HalfSceenWithBtn);
    public static UIData UIShop = new UIData("UISHOP", PrefabsID.UIShopPath, "UIShop", UIMode.HalfSceenWithBtn);

    public static UIData UIGame = new UIData("UIGAME", PrefabsID.UIGamePath, "UIGame", UIMode.AllScreen);
    public static UIData UIStop = new UIData("UISTOP", PrefabsID.UIStopPath, "UIStop", UIMode.AllScreen);
    public static UIData UIQuit = new UIData("UIQUIT", PrefabsID.UIQuitPath, "UIQuit", UIMode.AllScreen);
}
