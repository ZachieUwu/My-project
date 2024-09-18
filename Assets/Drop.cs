using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Drop
{
    public string ItemName;
    public GameObject ItemPrefab;
    [Range(0,100)]
    public float DropChance;
    public float Duration;
    public int min, max;
}
