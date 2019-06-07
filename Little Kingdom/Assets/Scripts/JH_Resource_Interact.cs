using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Resource_Interact : MonoBehaviour
{
    public JH_Game_Manager.ResourceType resourceType;
    public int in_resourceHealth;

    // Start is called before the first frame update
    void Start()
    {
        ResourceSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResourceSetup()
    {
        // Sets up the resource when it spawns in

        switch(resourceType)
        {
            case JH_Game_Manager.ResourceType.Food:
                {
                    in_resourceHealth = 1;
                }
                break;

            case JH_Game_Manager.ResourceType.Stone:
            case JH_Game_Manager.ResourceType.Wood:
                {
                    in_resourceHealth = 6;
                }
                break;

            case JH_Game_Manager.ResourceType.Iron:
                {
                    in_resourceHealth = 10;
                }
                break;

            default:
                {
                    Debug.LogWarning(gameObject + " resource type out of range");
                }
                break;
        }
    }
}
