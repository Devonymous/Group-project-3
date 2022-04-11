using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionInventory : MonoBehaviour
{
    public static PotionInventory Instance;
    public List<Potion> Potions = new List<Potion>();

    public Transform PotionContent;
    public GameObject InventoryPotion;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Potion potion)
    {
        Potions.Add(potion);
        Debug.Log("Potion Added To The HUD");
        //item.count++;
    }
    public void Remove(Potion potion)
    {
        Potions.Remove(potion);
        //Potion.count--;
    }
    public void Listpotions()
    {
        //foreach (Transform potion in PotionContent)
        //{
        //    Destroy(potion.gameObject);
        //}
        foreach (var potion in Potions)
        {
            GameObject obj = Instantiate(InventoryPotion, PotionContent);
            //var Potionname = obj.transform.Find("ItemName").GetComponent<Text>();
            var PotionIcon = obj.transform.Find("PotionIcon").GetComponent<Image>();

            //Potionname.text = potion.kind;
            PotionIcon.sprite = potion.icon;
        }
    }


    //private void OnApplicationQuit()
    //{
    //    foreach (var potion in Potions)
    //    {
    //        item.count = 0;
    //    }
    //}
}
