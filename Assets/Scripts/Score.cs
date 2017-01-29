using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private int score = 0;
    private TextMesh textMesh;
    private string label;
	void Start () {
        textMesh = gameObject.GetComponent<TextMesh>();
        label = textMesh.text;
	}
	
	void Update () {
        textMesh.text = label + score;
	}

    public void IncrementScore()
    {
        score++;
    }
}
