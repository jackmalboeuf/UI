using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    PlayableDirector director;
    [SerializeField]
    PlayableAsset playAsset;
    [SerializeField]
    List<Cinemachine.CinemachineVirtualCamera> cameras = new List<Cinemachine.CinemachineVirtualCamera>();
    int startTime = 0;
    double[] startTimes = new double[4] { 1, 3, 5, 7 };

    private void Start()
    {
        //StartCoroutine(ButtonWait(0));
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        cameras[0].gameObject.SetActive(true);
    }
    
    public void PressButton(int num)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        cameras[num].gameObject.SetActive(true);
        /*if (goesUp == true)
            startTime++;
        else if (goesUp == false)
            startTime--;

        if (startTime >= 4)
            startTime = 0;
        if (startTime <= -1)
            startTime = 3;
        print(startTime);
        director.time = startTimes[startTime];
        director.Play(playAsset);
        StartCoroutine(ButtonWait(1));*/
    }

    IEnumerator ButtonWait(float waitTime)
    {
        //director.transform.GetChild(0).GetComponent<Animator>().SetBool("ShouldSway", false);
        yield return new WaitForSeconds(waitTime + 0.1f);
        director.playableGraph.GetRootPlayable(0).Pause();
        //director.transform.GetChild(0).GetComponent<Animator>().SetBool("ShouldSway", true);
    }
}
