using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Send_Damage : MonoBehaviour
{
    public int in_damageDealt;
    public float fl_damageForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Deals damage and forces target away from the attacker
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<JH_Character_Health>() != null)
        {
            if (other.GetComponent<JH_Character_Health>().owningTeam != transform.parent.GetComponent<JH_Character_Health>().owningTeam)
            {
                other.GetComponent<JH_Character_Health>().in_characterHealth -= in_damageDealt;
                other.attachedRigidbody.AddForce((transform.forward * fl_damageForce) + 
                                                  transform.up * (fl_damageForce / 2), 
                                                  ForceMode.Impulse);
                gameObject.SetActive(false);
            }
        }
    }
}
