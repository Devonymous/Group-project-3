using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipe : MonoBehaviour
{
	public Sprite potionResult; 

	public Button potion;

	void Start()
	{
		Button btn = potion.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		GetComponent<Image>().sprite = potionResult;
	}
}
