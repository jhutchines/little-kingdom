using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Camera_Control : MonoBehaviour
{
    public GameObject go_mouseObjectHit;
    public GameObject go_playerObjectHit;
    public GameObject go_playerCharacter;

    private GameObject go_mouseObjectParent;
    private GameObject go_playerObjectParent;

    // Start is called before the first frame update
    void Start()
    {
        go_playerCharacter = GameObject.Find("Player");
        go_mouseObjectHit = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (go_playerCharacter == null) go_playerCharacter = GameObject.Find("Player");

        CheckBlock();
    }

    // Used to turn certain objects transparent
    void CheckBlock()
    {
        Vector3 v3_localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);

        RaycastHit mouseHit;
        RaycastHit playerHit;

        // Makes certain objects transparent if the mouse is over it
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mouseHit, Mathf.Infinity))
        {
            if (mouseHit.transform.parent == null) go_mouseObjectHit = mouseHit.transform.gameObject;
            else
            {
                go_mouseObjectParent = mouseHit.transform.gameObject;
                FindMouseParent();
            }
        }

        // Makes certain objects transparent if the player is behind it
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2)), 
                            out playerHit, Mathf.Infinity))
        {
            if (playerHit.transform.parent == null) go_playerObjectHit = playerHit.transform.gameObject;
            else
            {
                go_playerObjectParent = playerHit.transform.gameObject;
                FindPlayerParent();
            }
        }
        
    }

    // Finds the highest parent object of the object the mouse is over
    void FindMouseParent()
    {
        while (go_mouseObjectParent.transform.parent != null)
        {
            go_mouseObjectHit = go_mouseObjectParent.transform.parent.gameObject;
            go_mouseObjectParent = go_mouseObjectHit;
        }
    }

    // Finds the highest parent object of the object the player is behind
    void FindPlayerParent()
    {
        while (go_playerObjectParent.transform.parent != null)
        {
            go_playerObjectHit = go_playerObjectParent.transform.parent.gameObject;
            go_playerObjectParent = go_playerObjectHit;
        }
    }
}
