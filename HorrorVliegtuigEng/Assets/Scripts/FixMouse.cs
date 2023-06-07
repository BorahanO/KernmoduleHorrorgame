using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FixMouse : MonoBehaviour
{
    private void Start()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name == "Dialogue1" || name == "Dialogue2" || name == "Dialogue3" || name == "Dialogue4" || name == "Dialogue5" || name == "Dialogue6" || name == "Menu")
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
