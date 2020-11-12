using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourse : MonoBehaviour
{
   public List<NPC> _myNpc = new List<NPC>(); 
    public List<NPC> MyNpc 
    { 
        get => _myNpc;
        set => _myNpc = value; 
    }

    public void Inst()
    { 

    }
}
