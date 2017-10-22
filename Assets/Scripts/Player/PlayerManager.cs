using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    //存值
    public static void setPlayerNum(string name, object num, bool isAdd = false)
    {
        if(string.IsNullOrEmpty(name))
        {
            return;
        }

        string type = string.Empty;
        type = getTypeByName(name);

        switch (type)
        {
            case "int":
                int intNum = (int)num;
                if (isAdd)
                {
                    intNum = PlayerPrefs.GetInt(name);
                    intNum += (int)num;
                }
                PlayerPrefs.SetInt(name, intNum);
                break;
            case "float":
                float floatNum = (float)num;
                 if (isAdd)
                 {
                     floatNum = PlayerPrefs.GetFloat(name);
                     floatNum += (float)num;
                 }
                PlayerPrefs.SetFloat(name, floatNum);
                break;
            case "string":
                PlayerPrefs.SetString(name, (string)num);
                break;
        }
    }


    //取值
    public static object getPlayerNum(string name)
    {
        object playerNum = null;
        string type = string.Empty;

        type = getTypeByName(name);

        switch (type)
        {
            case "int":
                playerNum = PlayerPrefs.GetInt(name);
                break;
            case "float":
                playerNum = PlayerPrefs.GetFloat(name);
                break;
            case "string":
                playerNum = PlayerPrefs.GetString(name);
                break;
        }

        return playerNum;
    }

    private static string getTypeByName(string name)
    {
        string type = string.Empty;
        switch (name)
        {
            case GlobalVar.PlayerPrefsName.COIN_NAME:
                type = "int";
                break;
            case GlobalVar.PlayerPrefsName.BAMBOO_NAME:
                type = "int";
                break;
            case GlobalVar.PlayerPrefsName.PANDA_TYPE:
                type = "int";
                break;
            case GlobalVar.PlayerPrefsName.GAME_BAMBOO_NAME:
                type = "int";
                break;
            case GlobalVar.PlayerPrefsName.GAME_COIN_NAME:
                type = "int";
                break;
            case GlobalVar.PlayerPrefsName.PANDA_DISTANCE:
                type = "int";
                break;
            case GlobalVar.PlayerPrefsName.GAME_PANDA_DISTANCE:
                type = "int";
                break;
            default:
                type = "string";
                break;
        }
        return type;
    }
}
