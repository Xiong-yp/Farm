using UnityEngine.UI;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    protected abstract void InitUI();
    protected abstract void AddEventListener();
    protected abstract void RemoveEventListener();
    protected abstract void Dispose();
    public void Execute()
    {
        InitUI();
        AddEventListener();
    }
    public void DisposeAll()
    {
        RemoveEventListener();
        Dispose();
    }
}
