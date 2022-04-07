using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CraftingRecipe : MonoBehaviour
{
	public Image potionResult; 

	public Button potionSpeed, potionJump;
	public Sprite iconPotion, iconSpeed, iconJump;

	public InvenManager im;

	void Start()
	{
		//Button btn = GameObject.Find("Jump Potion Button").GetComponent<Button>();
		potionSpeed.onClick.AddListener(SpeedPotion);
		potionJump.onClick.AddListener(JumpPotion);
	}


	void SpeedPotion()
    {
		if (im.countPCrystal > 0 && im.countBCrystal > 0)
		{
			potionResult.sprite = iconSpeed;
		}
		else
		{
			Debug.Log("RecipeNO");
		}
    }

	void JumpPotion()
	{
		if (im.countCarrot > 0 && im.countBCrystal > 0)
		{
			potionResult.sprite = iconJump;
		}
		else
		{
			Debug.Log("RecipeNO");
		}
	}

}
