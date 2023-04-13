using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimWin : MonoBehaviour
{
    public static UiAnimWin instance;
    
    public Animator anim;
    private bool menuOpen = false;
    public GameObject winMenu;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void OpenMenu()
    {
        anim.SetBool("isWin", true);
        Cursor.visible = true;
    }

    public void CloseMenu()
    {
        anim.SetBool("isWin", false);
        Cursor.visible = false;
    }
}
