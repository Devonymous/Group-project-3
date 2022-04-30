// Scriptable Object Potion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion/Create new potion")]
public class Potion : ScriptableObject
{
    public Sprite icon;
    public Item ingr1, ingr2;
    public string kind;
    public int id;
}
