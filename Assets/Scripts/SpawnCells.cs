using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCells : MonoBehaviour {
    public GameObject cell;

	// Use this for initialization
	void Start () {
        for (var x = -9.5; x <= 9.5; x++)
        {
            for (var z = -9.5; z <= 9.5; z++)
            {
                var cellObj = Instantiate(cell);
                cellObj.transform.position = new Vector3((float)x, 3f, (float)z);
                cellObj.transform.localScale = new Vector3(1f, 5f, 1f);
            }
        }
	}
}
