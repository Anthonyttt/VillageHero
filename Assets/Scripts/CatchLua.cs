using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;
using XLua;

public class CatchLua : MonoBehaviour
{
    public byte[] MyCustomLoader(ref string filepath)
    {
        string path = Application.dataPath + "/Lua/" + filepath + ".lua";
        if (File.Exists(path))
        {
            string fileContent = File.ReadAllText(path, Encoding.Default);
            return Encoding.Default.GetBytes(fileContent);
        }
        
        return null;
    }

    public Player MapToPlayer()
    {
        LuaEnv luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.DoString("require('CharacterProp')");
        luaEnv.Global.Get("player", out Player player);
        return player;
    }

    public float ToHealthy(string type)
    {
        LuaEnv luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.DoString("require('CharacterProp')");
        return luaEnv.Global.Get<float>(type+"Healthy");
    }
}
