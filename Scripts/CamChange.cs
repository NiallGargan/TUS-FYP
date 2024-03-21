using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject ThirdPCam;
    public GameObject FirstPCam;
    public int CamMode = 1;
    public KeyCode changeCam = KeyCode.T;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(changeCam))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(changeView() );
        }
    }

    IEnumerator changeView()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            ThirdPCam.SetActive(true);
            FirstPCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            ThirdPCam.SetActive(false);
            FirstPCam.SetActive(true);
        }
    }
}
