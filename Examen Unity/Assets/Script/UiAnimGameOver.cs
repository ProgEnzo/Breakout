using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimGameOver : MonoBehaviour
{
    public static UiAnimGameOver instance;
    
    public Animator anim;
    private bool menuOpen = false;
    public GameObject gameOverMenu;

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
        anim.SetBool("isGameOver", true);
        Cursor.visible = true;
    }

    public void CloseMenu()
    {
        anim.SetBool("isGameOver", false);
        Cursor.visible = false;
    }
}
