using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_UI_Select_Item : MonoBehaviour
{
    public JH_Game_Manager.ItemType itemType;

    private GameObject go_player;

    // Start is called before the first frame update
    void Start()
    {
        go_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SelectItem();
    }

    // Equips the item attached to the number key pressed
    void SelectItem()
    {
        if (Input.GetKeyDown((transform.GetSiblingIndex() + 1).ToString()))
        {
            if (itemType == go_player.GetComponent<JH_Player_Inventory>().itemEquipped)
            {
                go_player.GetComponent<JH_Player_Inventory>().itemEquipped = JH_Game_Manager.ItemType.None;
            }
            else go_player.GetComponent<JH_Player_Inventory>().itemEquipped = itemType;
        }
    }
}
