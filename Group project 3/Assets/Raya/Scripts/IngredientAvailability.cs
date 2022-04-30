// Blackens the ingredients icons in the Craft Menu when they're not available

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientAvailability : MonoBehaviour
{
    public Item item;
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if(item.count < 1)
        {
            image.color = Color.black;
        }
        else 
        {
            image.color = Color.white;
        }
    }
}
