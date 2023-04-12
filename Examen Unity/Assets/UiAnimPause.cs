using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimPause : MonoBehaviour
{
    public static UiAnimPause instance;
    
    public Animator anim;
    private bool menuOpen = false;
    public GameObject pauseMenu;

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

    private void Update()
    {
        CloseMenu();
    }

    public void OpenMenu()
    {
        if (!menuOpen)
        {
            anim.SetBool("isPauseOpen", true);
            menuOpen = true;
        }
    }

    public void CloseMenu()
    {
        if (menuOpen)
        {
            anim.SetBool("isPauseOpen", false);
            menuOpen = false;
        }
    }
}
