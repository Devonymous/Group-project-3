using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CraftingRecipe : MonoBehaviour
{
	public Image potionResult;
	public Potion potion;
    Potion finalPotion;
    //public Sprite notAvailable;

    public void RecipePotion()
    {
        //potionResult.sprite = notAvailable;
        GameObject craftButton = GameObject.Find("Craft");
        CraftingRecipe CR = craftButton.GetComponent<CraftingRecipe>();
        
		if(potion.ingr1.count > 0 && potion.ingr2.count > 0)
        {
            potionResult.sprite = potion.icon;
            CR.finalPotion = potion;
        }
        
        
	}

    public void CraftPotion()
    {
        InvenManager.Instance.Remove(finalPotion.ingr1);
        InvenManager.Instance.Remove(finalPotion.ingr2);
        Debug.Log("Crafted " + finalPotion.kind);
        Debug.Log("Left: " + finalPotion.ingr1.count + " and " + finalPotion.ingr2.count);
    }

}
