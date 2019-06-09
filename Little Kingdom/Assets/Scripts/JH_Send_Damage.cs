using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Send_Damage : MonoBehaviour
{
    public int in_damageDealt;
    public float fl_damageForce;

    public int in_gatherDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Deals damage and forces target away from the attacker
        if (other.GetComponent<JH_Character_Health>() != null)
        {
            if (other.GetComponent<JH_Character_Health>().owningTeam != transform.parent.GetComponent<JH_Character_Health>().owningTeam)
            {
                other.GetComponent<JH_Character_Health>().in_characterHealth -= in_damageDealt;
                other.attachedRigidbody.AddForce((transform.forward * fl_damageForce),
                                                  ForceMode.Impulse);
                gameObject.SetActive(false);
            }
        }

        // Allows the player to gather resources if correct item is equipped
        if (other.GetComponent<JH_Resource_Interact>() != null)
        {
            if (other.GetComponent<JH_Resource_Interact>().in_resourceHealth > 0)
            {
                if (other.GetComponent<JH_Resource_Interact>().itemType == transform.parent.GetComponent<JH_Player_Inventory>().itemEquipped)
                {
                    other.GetComponent<JH_Resource_Interact>().in_resourceHealth -= in_gatherDamage;
                    transform.parent.GetComponent<JH_Player_Inventory>().LoseDurability();
                    other.GetComponent<JH_Resource_Interact>().ResourceHit();
                }
            }
        }
    }
}
