using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Transparency : MonoBehaviour
{
    public JH_Game_Manager.TransparentType transparentType;
    private JH_Camera_Control m_camera;

    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main.gameObject.GetComponent<JH_Camera_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTransparent();
    }

    void CheckTransparent()
    {
        if (m_camera.go_mouseObjectHit == gameObject || m_camera.go_playerObjectHit == gameObject)
        {
            MakeTransparent();
        }
        else
        {
            MakeOpaque();
        }


        if (transparentType == JH_Game_Manager.TransparentType.All)
        {
            if (m_camera.go_mouseObjectHit == gameObject ||  m_camera.go_playerObjectHit == gameObject)
            {
                MakeAllTransparent();
            }
            else
            {
                MakeAllOpaque();
            }
        }
    }

    void MakeTransparent()
    {
        Color c_changeAlpha = GetComponent<Renderer>().material.color;
        c_changeAlpha.a = 0.4f;
        GetComponent<Renderer>().material.color = c_changeAlpha;
    }

    void MakeOpaque()
    {
        Color c_changeAlpha = GetComponent<Renderer>().material.color;
        c_changeAlpha.a = 1f;
        GetComponent<Renderer>().material.color = c_changeAlpha;
    }

    void MakeAllTransparent()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Color c_changeAlpha = transform.GetChild(i).GetComponent<Renderer>().material.color;
            c_changeAlpha.a = 0.4f;
            transform.GetChild(i).GetComponent<Renderer>().material.color = c_changeAlpha;
        }
    }

    void MakeAllOpaque()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Color c_changeAlpha = transform.GetChild(i).GetComponent<Renderer>().material.color;
            c_changeAlpha.a = 1f;
            transform.GetChild(i).GetComponent<Renderer>().material.color = c_changeAlpha;
        }
    }
}
