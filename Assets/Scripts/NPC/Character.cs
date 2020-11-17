using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character<T>: MonoBehaviour where T: Character<T>
{
    public void mCharacterID;
    public int mHp;
    public string mName;

    protected static Dictionary<int,T> CharactersInstance;

    protected void SelfInit() //角色初始化
    {
        CharactersInstance.Add((T)this);
    }
    
    protected abstract void SelfMove();    //角色移动
    protected abstract void SelfDestory(); //角色销毁

}