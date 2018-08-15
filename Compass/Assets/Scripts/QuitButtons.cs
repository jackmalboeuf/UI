using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtons : MonoBehaviour
{
    [SerializeField]
    GameObject quitPanel;
    [SerializeField]
    CursorState cState;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitPanel.SetActive(!quitPanel.activeSelf);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        quitPanel.SetActive(false);
        cState.ToggleCursorState();
    }
}
