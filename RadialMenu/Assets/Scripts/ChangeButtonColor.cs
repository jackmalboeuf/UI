using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Color startColor;
    [SerializeField]
    GameObject transitionImage;
    [SerializeField]
    AnimationCurve pointerEnterCurve;

    Color onColor;
    Color offColor;
    Color highlightedColor;

    float alphaDifference = 0.1f;
    float fadeTime = 0.2f;
    bool shouldFadeUp = false;
    bool shouldFadeDown = false;
    float increment = 0.01f;
    float curveTime = 0;

    private void Start()
    {
        onColor = startColor;
        offColor = new Color(startColor.r, startColor.g, startColor.b, startColor.a - 2 * alphaDifference);
        highlightedColor = new Color(startColor.r, startColor.g, startColor.b, startColor.a - alphaDifference);

        transform.GetChild(0).GetComponent<Image>().color = startColor;
    }

    private void Update()
    {
        if (shouldFadeUp)
        {
            //transform.GetChild(0).GetComponent<Image>().color = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, transform.GetChild(0).GetComponent<Image>().color.a + increment);
            //print(transform.GetChild(0).GetComponent<Image>().color.a);
            curveTime += Time.deltaTime;
            transitionImage.transform.localPosition = new Vector2(transitionImage.transform.localPosition.x, transitionImage.transform.localPosition.y + pointerEnterCurve.Evaluate(curveTime));
        }
        else if (shouldFadeDown)
        {
            curveTime += Time.deltaTime;
            transitionImage.transform.localPosition = new Vector2(transitionImage.transform.localPosition.x, transitionImage.transform.localPosition.y - pointerEnterCurve.Evaluate(curveTime));
            //transform.GetChild(0).GetComponent<Image>().color = new Color(transform.GetChild(0).GetComponent<Image>().color.r, transform.GetChild(0).GetComponent<Image>().color.g, transform.GetChild(0).GetComponent<Image>().color.b, transform.GetChild(0).GetComponent<Image>().color.a - increment);
        }
    }

    public void OnButtonPressed()
    {
        if (GetComponent<Toggle>().isOn == true)
        {
            StartCoroutine(FadeToColor(1));
            //transform.GetChild(0).GetComponent<Image>().color = onColor;
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            StartCoroutine(FadeToColor(2));
            //transform.GetChild(0).GetComponent<Image>().color = offColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //transform.GetChild(0).GetComponent<Image>().color = highlightedColor;
        if (GetComponent<Toggle>().isOn == true)
        {
            curveTime = 0;
            StartCoroutine(FadeToColor(2));
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            curveTime = 0;
            StartCoroutine(FadeToColor(1));
        }
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

    IEnumerator FadeToColor(float upOrDown)
    {
        if (upOrDown == 1)
        {
            shouldFadeUp = true;
        }
        else if (upOrDown == 2)
        {
            shouldFadeDown = true;
        }

        yield return new WaitForSeconds(fadeTime);

        if (upOrDown == 1)
        {
            shouldFadeUp = false;
        }
        else if (upOrDown == 2)
        {
            shouldFadeDown = false;
        }

        /*if (buttonColor.a > colorToChangeTo.a)
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, buttonColor.a - amountToChange);
        else if (buttonColor.a < colorToChangeTo.a)
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, buttonColor.a + fadeTime / 100);*/

        /*for (float i = 0.01f; i < fadeTime; i += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            buttonColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, buttonColor.a + amountToChange);
        }*/
    }
}
