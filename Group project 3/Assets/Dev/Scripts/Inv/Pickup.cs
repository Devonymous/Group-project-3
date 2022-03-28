using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool Pickup_able = false;
    public GameObject Herb;
    public GameObject UI_e;
    public ItemController ItemData;
    void Update()
    {
        _Pickup();
        
    }

    public void _Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Pickup_able == true) 
            {
                ItemData = Herb.GetComponent<ItemController>();
                ItemData.Pickup();
                Destroy(Herb);
                Herb = null;
                UI_e.SetActive(false);
                Pickup_able = false;
            }
        }
    }

    void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.tag == "Herb & Gem")
        {
            Pickup_able = true;
            UI_e.SetActive(true);
            Herb = Other.gameObject; 
        }
    }
    void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject.tag == "Herb & Gem")
        {
            UI_e.SetActive(false);
            Pickup_able = false;
        }
    }

}
