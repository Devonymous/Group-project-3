using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipe : MonoBehaviour
{
	public Sprite speedP; 
	public Sprite jumpP;

	public Button potion;

	void Start()
	{
		Button btn = potion.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		GetComponent<Image>().sprite = speedP;
	}
}
