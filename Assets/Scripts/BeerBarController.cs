using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerBarController : MonoBehaviour
{
    private Transform bar;
    public GameObject BarSprite;
    private SpriteRenderer barRenderer;

    void Start()
    {
        bar = transform.Find("Bar");
        barRenderer = BarSprite.GetComponent<SpriteRenderer>();
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public float GetSize()
    {
        return bar.localScale.x;
    }

    public void SetEmptyColor()
    {
        barRenderer.color = new Color(255f, 0f, 0f, 1f);
    }

    public void SetDefaultColor()
    {
        barRenderer.color = new Color(255f, 255f, 255f, 255f);
    }



}
