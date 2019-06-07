using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Player_Attack : MonoBehaviour
{
    public GameObject go_attackTrigger;
    public GameObject go_weapon;
    public bool bl_canAttack = true;
    public float fl_attackLength;

    private Quaternion q_weaponStartRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (go_attackTrigger == null)
        {
            go_attackTrigger = GameObject.Find("Player Attack Trigger");
        }
        if (go_weapon == null)
        {
            go_weapon = GameObject.Find("Player Weapon");
        }

        go_attackTrigger.SetActive(false);

        q_weaponStartRotation = go_weapon.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        // Activates the weapon swinging
        if (bl_canAttack)
        {
            go_weapon.transform.localRotation = q_weaponStartRotation;
            go_weapon.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            go_weapon.transform.GetChild(0).gameObject.SetActive(true);
            MoveWeapon();
        }
    }

    // Begins the attack sequence if the player is able to attack
    public void StartAttack()
    {
        if (bl_canAttack)
        {
            StartCoroutine(UseAttack());
        }
    }

    // Turns on the GameObject responsible for sending damage to enemies
    IEnumerator UseAttack()
    {
        bl_canAttack = false;
        go_attackTrigger.SetActive(true);
        yield return new WaitForSeconds(fl_attackLength);
        go_attackTrigger.SetActive(false);
        bl_canAttack = true;
    }

    // Makes the player character swing the weapon they are holding
    void MoveWeapon()
    {
        go_weapon.transform.Rotate(new Vector3(0, 2 / fl_attackLength, 0));
    }
}
