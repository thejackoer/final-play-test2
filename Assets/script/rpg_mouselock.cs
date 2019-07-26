using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpg_mouselock : MonoBehaviour
{
    private static bool mouseLocked;

    public static bool Mouselocked
    {
        get
        {
            return mouseLocked;
        }
        set
        {
            mouseLocked = value;

            if (mouseLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }



        }
    }
}
