using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Item Item;

    public void Pickup()
    {
        InvenManager.Instance.Add(Item);
    }
}
