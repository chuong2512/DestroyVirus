using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class VirusSO : ScriptableObject
{
    public ViruInfo[] data;

    public ViruInfo GetInfo(int ID)
    {
        return data.First(info => info.ID == ID);
    }
}

[Serializable]
public class ViruInfo
{
    [SerializeField] public int ID;
    [SerializeField] public int HP = 1;
    [SerializeField] public int Point = 1;
    [SerializeField] public float Scale = 1;
    [SerializeField] public Sprite Icon;
    [SerializeField] public Sprite FX;
    [SerializeField] public bool IsBoss;
}