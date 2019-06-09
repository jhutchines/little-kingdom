using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Resource_Interact : MonoBehaviour
{
    public JH_Game_Manager.ResourceType resourceType;
    public JH_Game_Manager.ItemType itemType;
    public int in_resourceHealth;

    public Animator anim_resource;
    private bool bl_canInteract = true;
    private bool bl_moveResource;
    private Vector3 v3_moveTowards;

    // Start is called before the first frame update
    void Start()
    {
        ResourceSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (bl_moveResource)
        {
            ResourceMove();
        }
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

    // Resource node takes damage and drops items when hit
    public void ResourceHit()
    {
        if (in_resourceHealth > 0)
        {
            anim_resource.Play("Resource Hit");
        }

        else
        {
            if (bl_canInteract) StartCoroutine(ResourceDestroy());
        }
    }

    // Used for when the resource node has been depleted
    void ResourceMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, v3_moveTowards, 0.05f);
        if (transform.position == v3_moveTowards) Destroy(gameObject);
    }

    // Leaves the resource node in the world for a few seconds after being depleted
    IEnumerator ResourceDestroy()
    {
        bl_canInteract = false;
        yield return new WaitForSeconds(5);
        v3_moveTowards = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
        bl_moveResource = true;
    }
}
