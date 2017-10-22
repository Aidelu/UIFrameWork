using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{

    public static int CoinNum//总的金币数目
    {
        set
        {
            PlayerManager.setPlayerNum(GlobalVar.PlayerPrefsName.COIN_NAME, value, true);
        }

        get
        {
            return (int)PlayerManager.getPlayerNum(GlobalVar.PlayerPrefsName.COIN_NAME);
        }
    }

    public static int BambooNum//总的竹笋数目
    {
         set
        {
            PlayerManager.setPlayerNum(GlobalVar.PlayerPrefsName.BAMBOO_NAME, value, true);
        }

        get
        {
            return (int)PlayerManager.getPlayerNum(GlobalVar.PlayerPrefsName.BAMBOO_NAME);
        }
    }
    public static int GameCoinNum//单局金币数目
    {
        set
        {
            PlayerManager.setPlayerNum(GlobalVar.PlayerPrefsName.GAME_COIN_NAME, value);
        }

        get
        {
            return (int)PlayerManager.getPlayerNum(GlobalVar.PlayerPrefsName.GAME_COIN_NAME);
        }
    }

    public static int GameBambooNum//当局竹笋数目
    {
        set
        {
            PlayerManager.setPlayerNum(GlobalVar.PlayerPrefsName.GAME_BAMBOO_NAME, value);
        }

        get
        {
            return (int)PlayerManager.getPlayerNum(GlobalVar.PlayerPrefsName.GAME_BAMBOO_NAME);
        }
    }

    public static int PandaType
    {
        set
        {
            PlayerManager.setPlayerNum(GlobalVar.PlayerPrefsName.PANDA_TYPE, value);
        }

        get
        {
            return (int)PlayerManager.getPlayerNum(GlobalVar.PlayerPrefsName.PANDA_TYPE);
        }
    }

    public static int PandaDistance
    {
        set
        {
            PlayerManager.setPlayerNum(GlobalVar.PlayerPrefsName.PANDA_DISTANCE, value, true);
        }

        get
        {
            return (int)PlayerManager.getPlayerNum(GlobalVar.PlayerPrefsName.PANDA_DISTANCE);
        }
    }

    public static int GamePandaDistance
    {
        set
        {
            PlayerManager.setPlayerNum(GlobalVar.PlayerPrefsName.GAME_PANDA_DISTANCE, value);
        }

        get
        {
            return (int)PlayerManager.getPlayerNum(GlobalVar.PlayerPrefsName.GAME_PANDA_DISTANCE);
        }
    }
}
