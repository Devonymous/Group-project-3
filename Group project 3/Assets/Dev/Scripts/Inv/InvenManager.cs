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

    public int countPCrystal, countBCrystal, countCarrot, countCoffee, countSCane, countMint, countMushroom;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        if (item.name == "Purple Crystal")
        {
            countPCrystal++;
        }
        else if (item.name == "Blue crystal")
        {
            countBCrystal++;
        }
        else if (item.name == "Carrot")
        {
            countCarrot++;
        }
        else if (item.name == "Coffee plant")
        {
            countCoffee++;
        }
        else if (item.name == "SugarCane")
        {
            countSCane++;
        }
        else if (item.name == "Mint")
        {
            countMint++;
        }
        else
        {
            countMushroom++;
        }
    }
    public void Remove(Item item)
    {
        Items.Remove(item);
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
            //ingr1++;
            //ingr2++;
            //if(Itemname.text == "Purple crystal")
            //{
            //    ingr1++;
            //}
            //else if (Itemname.text == "Blue crystal")
            //{
            //    ingr2++;
            //}
            ItemIcon.sprite = item.icon;
        }
    }
}
