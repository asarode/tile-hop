using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBillboard : MonoBehaviour {
    private Camera cam;
	
	void Start () {
        cam = Camera.main;
	}
	
	void Update () {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.y = cam.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(rot);
    }
}
