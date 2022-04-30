using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsList : MonoBehaviour
{
    public Image[] slots;
    int i;
    int selectedPotion;
    Potion activatedPotion;

    Movement movementScript;

    public List<Potion> Potions = new List<Potion>();

    KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
     };
    
    public void Start()
    {
        GameObject player = GameObject.Find("Player");
        movementScript = player.GetComponent<Movement>(); // Access to the movement script
    }


    private void Update()
    {
        SelectPotion();    // Which potion is selected in the HUD
        NoMorePotionCheck();    // Are any potions missing

        if (Input.GetKey(KeyCode.Tab))    // Potion gets activated by TAB
        {
            if(slots[selectedPotion].enabled == true)    // Checks if the selected slot has potion in it
            {
                FindPotionByID(selectedPotion);    // Finds a potion by ID and removes it from the list
                if (activatedPotion.id == 2)    // Enables the ability 
                {
                    movementScript.wallEnabled = true;
                }
            }
        }
    }

    // Finds a potion by ID and removes it from the list of potions
    void FindPotionByID(int myID)
    {
        for (int i = 0; i < Potions.Count; i++)
        {
            if (Potions[i].id == myID)
            {
                activatedPotion = Potions[i];
                Potions.Remove(Potions[i]);
                Debug.Log("Potion Removed");
            }
        }
    }

    // UI FUNCTIONS ----------------------------------------------------------------

    // Lists the crafted potions in the HUD
    public void PotionToHUD(List<Potion> Potions, Potion potion)
    {
        if (Potions.IndexOf(potion) < 0) // Checks if the potions is repeating
        {
            i = potion.id;
            Potions.Add(potion);
            slots[i].gameObject.SetActive(true);
            slots[i].sprite = potion.icon;
        }
    }

    // Selects/Highlights a potion from the HUD
    void SelectPotion()
    {
        slots[0].transform.parent.gameObject.GetComponent<Image>().color = Color.green;
        for (int j = 0; j < keyCodes.Length; j++)
        {
            if (Input.GetKeyDown(keyCodes[j]))
            {
                DeselectPotions();
                slots[j].transform.parent.gameObject.GetComponent<Image>().color = Color.green;
                selectedPotion = j;
            }
        }
    }

    // Clears the previously selected potions in the HUD
    void DeselectPotions()
    {
        for (int j = 0; j < slots.Length; j++)
        {
            slots[j].transform.parent.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    // Removes icons of potions that are missing
    void NoMorePotionCheck()
    {
        foreach (Potion potion in Potions)
        {
            int count = 0;

            for (int i = 0; i < Potions.Count; i++)
            {
                if (Potions[i] == potion)
                {
                    count++;
                }
            }

            if (count < 1)
            {
                slots[potion.id].enabled = false;
            }
        }
    }

}