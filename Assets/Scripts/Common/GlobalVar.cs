using UnityEngine;
using System.Collections;

//全局变量：只读
public class GlobalVar {

	public struct AnimName
    {
        public const string turnRight = "turn_right";
        public const string turnLeft = "turn_left";
        public const string rollDown = "turn_down";
        public const string jumpUp = "jump";
        public const string dead = "dead";
        public const string reLife = "relife";
    }

    public struct ObjectName
    {
        public const string pandaName = "Panda";
        public const string coin = "coin";
        public const string myCoinX2 = "myCoinX2";
        public const string magnet = "Magnet";
        public const string protect = "Protect";
        public const string sprint = "Sprint";
    }

    public struct EffectName
    {
        public const string coinCollectEffect = "coinCollectEffect";
        public const string doubleEffect = "doubleEffect";
        public const string magnetEffect = "magnetEffect";
        public const string shoeEffect = "shoeEffect";
        public const string starEffect = "starEffect";
    }

    public struct LayerName
    {
        public const string ground = "Ground";
    }

    public struct TagName
    {
        public const string luzhang = "luzhang";
    }

    public struct PlayerPrefsName
    {
        public const string COIN_NAME = "coinName";
        public const string BAMBOO_NAME = "bambooName";
        public const string PANDA_DISTANCE = "pandaDistance";
        public const string GAME_COIN_NAME = "gameCoinName";
        public const string GAME_BAMBOO_NAME = "gameBambooName";
        public const string GAME_PANDA_DISTANCE = "gamePandaDistance";
        public const string PANDA_TYPE = "pandaType";
    }
  
}
