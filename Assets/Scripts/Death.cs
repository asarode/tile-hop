using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    public bool IsDying
    {
        get { return isDying; }
    }
    private float flaggedForDeathAt;
    private float deathProcessLength = 5f;
    private bool isDying = false;
    private Renderer rend;
    private Color originalColor, finalColor;

    public void FlagForDeath()
    {
        flaggedForDeathAt = Time.time;
        isDying = true;
        Debug.Log("Flagged for death!");
    }

    void Start()
    {
        rend = gameObject.transform.Find("TopLayer").GetComponent<Renderer>();
        var matColor = rend.material.color;
        originalColor = new Color(matColor.r, matColor.g, matColor.b);
        float h, s, v;
        Color.RGBToHSV(originalColor, out h, out s, out v);
        finalColor = Color.HSVToRGB(h, s, 0f);
    }

    void Update()
    {
        if (isDying)
        {
            float progress = (Time.time - flaggedForDeathAt) / deathProcessLength;
            rend.material.color = Color.Lerp(originalColor, finalColor, progress);
        }
        if (isDying && Time.time > flaggedForDeathAt + deathProcessLength)
        {
            Destroy(gameObject);
        }
    }
}
