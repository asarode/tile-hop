using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;
public class CheckPlayerDeath : MonoBehaviour {

    private Transform headset;
    private Ray downRay;
    private RaycastHit hit;
    [SerializeField]
    private float deathFadeTime = 2f;
    private float deadlyExposureTime = 2f;
    private float exposureStartedAt = 0f;
    private VRTK_HeadsetFade headsetFade;

    void Start()
    {
        headset = VRTK_DeviceFinder.HeadsetTransform();
    }

    void Update () {
        downRay = new Ray(headset.position, Vector3.down);
        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.collider.tag == "Death Floor")
            {
                if (exposureStartedAt == 0f)
                {
                    exposureStartedAt = Time.time;
                }
                else if (Time.time > exposureStartedAt + deadlyExposureTime)
                {
                    headsetFade = GetComponent<VRTK_HeadsetFade>();
                    headsetFade.Fade(new Color(0.69f, 0.06f, 0.06f), deathFadeTime);
                    Invoke("RestartLevel", deathFadeTime);
                    
                }
                Debug.Log("Hit the danger zone!");
            }
            else
            {
                exposureStartedAt = 0f;
            }
        }
	}

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
