using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CraftingRecipe : MonoBehaviour
{
	public Image potionResult, potionResultIngr1, potionResultIngr2;
	public Potion potion;
    Potion finalPotion;
    public Sprite notAvailable;

    public void RecipePotion()
    {
        GameObject craftButton = GameObject.Find("Craft");
        CraftingRecipe CR = craftButton.GetComponent<CraftingRecipe>();
        
		if(potion.ingr1.count > 0 && potion.ingr2.count > 0)
        {
            potionResult.sprite = potion.icon;
            potionResultIngr1.sprite = potion.ingr1.icon;
            potionResultIngr2.sprite = potion.ingr2.icon;
            CR.finalPotion = potion;
        }
        else
        {
            potionResult.sprite = notAvailable;
        }
        
	}

    public void CraftPotion()
    {
        GameObject HUD = GameObject.Find("HUD (1)");
        PotionsList PL = HUD.GetComponent<PotionsList>();
        PL.PotionToHUD(finalPotion);
        InvenManager.Instance.Remove(finalPotion.ingr1);
        InvenManager.Instance.Remove(finalPotion.ingr2);
        
        Debug.Log("Crafted " + finalPotion.kind);
        Debug.Log("Left: " + finalPotion.ingr1.count + " and " + finalPotion.ingr2.count);
    }

}
