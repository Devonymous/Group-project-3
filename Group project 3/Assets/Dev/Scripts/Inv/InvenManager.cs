using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenManager : MonoBehaviour
{
    public static InvenManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        item.count++;
    }
    public void Remove(Item item)
    {
        Items.Remove(item);
        item.count--;
    }
    public void Listitems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem,ItemContent);
            var Itemname = obj.transform.Find("ItemName").GetComponent<Text>();
            var ItemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            Itemname.text = item.itemName;
            ItemIcon.sprite = item.icon;
        }
    }


    private void OnApplicationQuit()
    {
        foreach(var item in Items)
        {
            item.count = 0;
        }
    }
}
