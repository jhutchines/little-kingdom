using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Player_Inventory : MonoBehaviour
{
    public JH_Game_Manager.ItemType[] itemTypes;
    public JH_Game_Manager.ItemType itemEquipped;
    public JH_Game_Manager.ResourceType resourceType;
    public int[] itemDurability;



    // Start is called before the first frame update
    void Start()
    {
        InventorySetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets up the player's inventory using itemTypes array set up in the inspector
    void InventorySetup()
    {
        itemDurability = new int[itemTypes.Length];
        for (int i = 0; i < itemTypes.Length; i++)
        {
            if (itemTypes[i] == JH_Game_Manager.ItemType.Axe ||
            itemTypes[i] == JH_Game_Manager.ItemType.Pickaxe ||
            itemTypes[i] == JH_Game_Manager.ItemType.Sickle) itemDurability[i] = 50;
            if (itemTypes[i] == JH_Game_Manager.ItemType.Sword) itemDurability[i] = 100;
        }
    }

    // Reduces item durability when it is used
    public void LoseDurability()
    {
        for (int i = 0; i < itemTypes.Length; i++)
        {
            if (itemEquipped == itemTypes[i]) itemDurability[i]--;
        }
    }
}
