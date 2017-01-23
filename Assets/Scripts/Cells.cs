using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour {
    public GameObject cell;

    private float lastKilledAt = 0f;
    [SerializeField]
    private float killRate = 3f;

    private Dictionary<double, Dictionary<double, GameObject>> cellGrid;
    private List<GridCoord> coordsAlive;
    
    public void FlagForDeath(GridCoord coord)
    {
        cellGrid[coord.x][coord.z].GetComponent<Death>().FlagForDeath();
        coordsAlive.Remove(coord);
    }

    public void FlagRandomForDeath()
    {
        var randomCoord = coordsAlive[Random.Range(0, coordsAlive.Count - 1)];
        FlagForDeath(randomCoord);
    }

    void Start()
    {
        cellGrid = new Dictionary<double, Dictionary<double, GameObject>>();
        coordsAlive = new List<GridCoord>();
        for (var x = -9.5; x <= 9.5; x++)
        {
            var row = new Dictionary<double, GameObject>();
            cellGrid.Add(x, row);
            for (var z = -9.5; z <= 9.5; z++)
            {
                var cellObj = Instantiate(cell);
                cellObj.transform.position = new Vector3((float)x, 0f, (float)z);
                // cellObj.transform.localScale = new Vector3(1f, 5f, 1f);
                row.Add(z, cellObj);
                coordsAlive.Add(new GridCoord(x, z));
            }
        }
    }

    void Update()
    {

        if (coordsAlive.Count == 1)
        {
            Debug.Log("You won!");
        }
        else if (Time.time > lastKilledAt + killRate)
        {
            FlagRandomForDeath();
            lastKilledAt = Time.time;
            killRate = Mathf.Clamp(killRate * 0.95f, 1f, killRate);
        }
    }
}
