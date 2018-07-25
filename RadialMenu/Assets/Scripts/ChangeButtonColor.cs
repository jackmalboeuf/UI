using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Color startColor;

    Color onColor;
    Color offColor;
    Color highlightedColor;
    Color buttonColor;

    float alphaDifference = 0.1f;
    float fadeTime = 0.3f;

    private void Start()
    {
        onColor = startColor;
        offColor = new Color(startColor.r, startColor.g, startColor.b, startColor.a - 2 * alphaDifference);
        highlightedColor = new Color(startColor.r, startColor.g, startColor.b, startColor.a - alphaDifference);

        buttonColor = transform.GetChild(0).GetComponent<Image>().color;
    }

    public void OnButtonPressed()
    {
        if (GetComponent<Toggle>().isOn == true)
        {
            StartCoroutine(FadeToColor(onColor));
            //transform.GetChild(0).GetComponent<Image>().color = onColor;
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            StartCoroutine(FadeToColor(offColor));
            //transform.GetChild(0).GetComponent<Image>().color = offColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<Image>().color = highlightedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GetComponent<Toggle>().isOn == true)
        {
            transform.GetChild(0).GetComponent<Image>().color = onColor;
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            transform.GetChild(0).GetComponent<Image>().color = offColor;
        }
    }

    IEnumerator FadeToColor(Color colorToChangeTo)
    {
        Color saveColor = buttonColor;
        float numberOfTicks = 0.01f / fadeTime;
        float amountToChange = buttonColor.a - colorToChangeTo.a / numberOfTicks;

        /*if (buttonColor.a > colorToChangeTo.a)
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, buttonColor.a - amountToChange);
        else if (buttonColor.a < colorToChangeTo.a)
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, buttonColor.a + fadeTime / 100);*/

        for (float i = 0.01f; i < fadeTime; i += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, buttonColor.a + amountToChange);
        }
    }
}
