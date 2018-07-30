using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Vector2 offExitPosition;
    [SerializeField]
    Vector2 offEnterPosition;
    [SerializeField]
    Vector2 onExitPosition;
    [SerializeField]
    Vector2 onEnterPosition;
    [SerializeField]
    Transform transitionImage;
    [SerializeField]
    AnimationCurve transitionCurve;

    float fadeTime = 0.8f;
    float curveTime = 0;
    Vector2 savePosition;
    int positionNum;

    private void Update()
    {
        if (positionNum == 1)
        {
            curveTime += Time.deltaTime;
            transitionImage.transform.localPosition = Vector2.Lerp(savePosition, offExitPosition, transitionCurve.Evaluate(curveTime));
        }
        else if (positionNum == 2)
        {
            curveTime += Time.deltaTime;
            transitionImage.transform.localPosition = Vector2.Lerp(savePosition, offEnterPosition, transitionCurve.Evaluate(curveTime));
        }
        else if (positionNum == 3)
        {
            curveTime += Time.deltaTime;
            transitionImage.transform.localPosition = Vector2.Lerp(savePosition, onExitPosition, transitionCurve.Evaluate(curveTime));
        }
        else if (positionNum == 4)
        {
            curveTime += Time.deltaTime;
            transitionImage.transform.localPosition = Vector2.Lerp(savePosition, onEnterPosition, transitionCurve.Evaluate(curveTime));
        }
    }

    public void OnButtonPressed()
    {
        StopAllCoroutines();

        if (GetComponent<Toggle>().isOn == true)
        {
            savePosition = transitionImage.localPosition;
            curveTime = 0;
            StartCoroutine(FadeToColor(3));
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            savePosition = transitionImage.localPosition;
            curveTime = 0;
            StartCoroutine(FadeToColor(1));
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();

        if (GetComponent<Toggle>().isOn == true)
        {
            savePosition = transitionImage.localPosition;
            curveTime = 0;
            StartCoroutine(FadeToColor(4));
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            savePosition = transitionImage.localPosition;
            curveTime = 0;
            StartCoroutine(FadeToColor(2));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();

        if (GetComponent<Toggle>().isOn == true)
        {
            savePosition = transitionImage.localPosition;
            curveTime = 0;
            StartCoroutine(FadeToColor(3));
        }
        else if (GetComponent<Toggle>().isOn == false)
        {
            savePosition = transitionImage.localPosition;
            curveTime = 0;
            StartCoroutine(FadeToColor(1));
        }
    }

    IEnumerator FadeToColor(int whichPosition)
    {
        positionNum = whichPosition;

        yield return new WaitForSeconds(fadeTime);

        positionNum = 0;
    }
}
