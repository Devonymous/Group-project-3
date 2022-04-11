using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsList : MonoBehaviour
{
    public Image[] slots;
    int i = 0;

    public List<Potion> Potions = new List<Potion>();

    public void PotionToHUD(Potion potion)
    {
        if (!Potions.Contains(potion))
        {
            slots[i].gameObject.SetActive(true);
            slots[i].sprite = potion.icon;
            i++;
        }
    }
}