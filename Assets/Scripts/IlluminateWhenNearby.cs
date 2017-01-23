using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class IlluminateWhenNearby : MonoBehaviour {
    private Transform headset;
    [SerializeField]
    private float distanceCutoff = 2f;
    private Renderer rend;
    private Color originalColor;
    private Color finalColor;
	
	void Start () {
        headset = VRTK_DeviceFinder.HeadsetTransform();
        rend = gameObject.GetComponent<Renderer>();
        originalColor = rend.material.color;
        finalColor = rend.material.color;
        finalColor.a = 0;
        rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        var distanceToHeadset = Vector3.Distance(headset.position, new Vector3(transform.position.x, 5.5f, transform.position.z));
        var t = Mathf.Clamp(distanceToHeadset, 0f, distanceCutoff) / distanceCutoff;
        rend.material.color = Color.Lerp(originalColor, finalColor, t);
        rend.enabled = rend.material.color.a != 0f;
        var lerpedSize = Mathf.Lerp(50, 0, t);
        transform.position.Set(transform.position.x, lerpedSize / 2f + 5.5f, transform.position.z);
        transform.localScale.Set(transform.localScale.x, lerpedSize, transform.localScale.z);
	}
}
