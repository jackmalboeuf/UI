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
    }

    IEnumerator ButtonWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime + 0.1f);
        director.playableGraph.GetRootPlayable(0).Pause();
    }
}
