using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorState : MonoBehaviour
{
    bool isCursorLocked;

    void Start()
    {
        ToggleCursorState();
    }

    void Update()
    {
        CheckInput();
        CheckIfCursorShouldBeLocked();
    }

    public void ToggleCursorState()
    {
        isCursorLocked = !isCursorLocked;
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorState();
        }
    }

    void CheckIfCursorShouldBeLocked()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<CameraMouseLook>().enabled = true;
            transform.GetChild(0).GetComponent<CameraMouseLook>().enabled = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<CameraMouseLook>().enabled = false;
            transform.GetChild(0).GetComponent<CameraMouseLook>().enabled = false;

        }
    }
}
