using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    private Color[] Colors = new Color[4] { new Color(0.9f, 0.2f, 0.4f), new Color(0.9f, 0.6f, 0.7f), new Color(0.5f, 0.8f, 1.0f), new Color(0.3f, 0.6f, 0.8f) };
    public int index;
    void Awake()
    {
        index = Random.Range(0, Colors.Length);
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Colors[index];
    }
}
