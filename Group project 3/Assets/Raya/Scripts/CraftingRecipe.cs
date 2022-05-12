// Selecting a recipe and crafting it

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
    bool craftable = false;


    // Opens the recipe and checks if it is craftable
    public void RecipePotion()
    {
        ResetColors();
        GameObject craftButton = GameObject.Find("Craft");
        CraftingRecipe CR = craftButton.GetComponent<CraftingRecipe>();

        // Shows the clicked recipe
        potionResult.sprite = potion.icon;
        potionResultIngr1.sprite = potion.ingr1.icon;
        potionResultIngr2.sprite = potion.ingr2.icon;

        // Checks which ingredient is missing
        if(potion.ingr1.count < 1)
        {
            potionResultIngr1.color = Color.black;
        }

        if (potion.ingr2.count < 1)
        {
            potionResultIngr2.color = Color.black;
        }

        // Checks if the recipe is craftable
        if (potion.ingr1.count > 0 && potion.ingr2.count > 0)
        {
            CR.craftable = true;
            CR.finalPotion = potion;
        }
        else
        {
            potionResult.color = Color.black;
        }
        
    }

    // Crafts the potion of the selected recipe if it's craftable
    // and adds it to the HUD
    public void CraftPotion()
    {
        if (craftable)
        {
            // Puts the crafted potion in the HUD
            GameObject HUD = GameObject.Find("HUD");
            PotionsList PL = HUD.GetComponent<PotionsList>();
            PL.PotionToHUD(PL.Potions, finalPotion);

            //Removes the used ingredients from the inventory
            InvenManager.Instance.Remove(finalPotion.ingr1);
            InvenManager.Instance.Remove(finalPotion.ingr2);

            // Removes the recipe icons after crafting
            potionResult.sprite = notAvailable;
            potionResultIngr1.sprite = notAvailable;
            potionResultIngr2.sprite = notAvailable;
        }
    }

    // Resets the colors of the recipe icons
    void ResetColors()
    {
        potionResult.color = Color.white;
        potionResultIngr1.color = Color.white;
        potionResultIngr2.color = Color.white;
    }
}
