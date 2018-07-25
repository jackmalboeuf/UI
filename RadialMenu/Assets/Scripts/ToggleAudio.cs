using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource instrument;

    private void Start()
    {
        instrument.loop = true;
        instrument.Play();
        instrument.volume = 0;
    }

    public void OnToggle()
    {
        if (GetComponent<Toggle>().isOn == true)
        {
            instrument.volume = 1;
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            instrument.volume = 0;
        }
    }
}
