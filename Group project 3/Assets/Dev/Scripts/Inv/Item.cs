using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Item/Create new item")]
public class Item : ScriptableObject
{
    public string id;
    public string itemName;
    public int value;
    public Sprite icon;
    

}
