using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class CheckPlayerDeath : MonoBehaviour {

    private Transform headset;
    private Ray downRay;
    private RaycastHit hit;
    [SerializeField]
    private float deadlyExposureTime = 2f;
    private float exposureStartedAt = 0f;
	// Use this for initialization
	void Start () {
        headset = VRTK_DeviceFinder.HeadsetTransform();
    }
	
	// Update is called once per frame
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
                    Debug.Log("LTBHTF");
                }
                Debug.Log("Hit the danger zone!");
            }
            else
            {
                exposureStartedAt = 0f;
            }
        }
	}
}
