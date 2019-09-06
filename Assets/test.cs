using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
  XLua.LuaEnv _env;

  public static System.Action eClick;
	// Use this for initialization
	void Start () {
    _ReloadLua();
  }

  void _ReloadLua() {
    if (_env != null) {
      if (LuaEntry.Dispose != null) {
        LuaEntry.Dispose();
        //_env.DoString(@"print('随便再执行一行lua代码，重新创建env就不会报错')");
      }
      _env.Dispose();
      _env = null;
    }
    _env = new XLua.LuaEnv();
    _env.DoString(@"require 'main'");
    if (LuaEntry.Init != null) {
      LuaEntry.Init();
    }
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  private void OnGUI() {
    if (GUI.Button(new Rect(0, 0, 300, 100), "Click") && eClick != null) {
      eClick();
    }

    if (GUI.Button(new Rect(500, 0, 300, 100), "Reload")) {
      _ReloadLua();
    }
  }
}
