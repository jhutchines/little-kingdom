using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JH_UI_Inventory : MonoBehaviour
{
    public int[] in_inventorySlot;
    public Sprite[] sp_itemSprites;
    public Color c_selectedColor;

    private Color c_startColor;
    private GameObject go_player;
    
    // Start is called before the first frame update
    void Start()
    {
        go_player = GameObject.Find("Player");
        UIStart();
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();
    }

    // Sets up the UI inventory to display the correct items
    void UIStart()
    {
        c_startColor = transform.GetChild(0).GetComponent<Image>().color;
        c_selectedColor.a = c_startColor.a;

        in_inventorySlot = new int[go_player.GetComponent<JH_Player_Inventory>().itemTypes.Length];
        for (int i = 0; i < go_player.GetComponent<JH_Player_Inventory>().itemTypes.Length; i++)
        {
            if (go_player.GetComponent<JH_Player_Inventory>().itemTypes[i] == JH_Game_Manager.ItemType.Axe)
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = sp_itemSprites[0];
            }

            if (go_player.GetComponent<JH_Player_Inventory>().itemTypes[i] == JH_Game_Manager.ItemType.Pickaxe)
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = sp_itemSprites[1];
            }

            if (go_player.GetComponent<JH_Player_Inventory>().itemTypes[i] == JH_Game_Manager.ItemType.Sickle)
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = sp_itemSprites[2];
            }

            if (go_player.GetComponent<JH_Player_Inventory>().itemTypes[i] == JH_Game_Manager.ItemType.Sword)
            {
                transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = sp_itemSprites[3];
            }
        }
    }

    void UIUpdate()
    {
        for (int i = 0; i < go_player.GetComponent<JH_Player_Inventory>().itemTypes.Length; i++)
        {
            if (go_player.GetComponent<JH_Player_Inventory>().itemTypes[i] == go_player.GetComponent<JH_Player_Inventory>().itemEquipped)
            {
                transform.GetChild(i).GetComponent<Image>().color = c_selectedColor;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().color = c_startColor;
            }
        }
    }
}
