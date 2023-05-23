using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    public ComboManager comboManager;
    public float size = 0.1f;

    private TextMesh textMesh;

    private void Start()
    {
        // Get the existing TextMesh component
        textMesh = GetComponent<TextMesh>();

        // Set the initial text
        textMesh.text = "Combo: 0";
    }

    private void Update()
    {
        // Update the text with the current combo value
        textMesh.text = "Combo: " + comboManager.combo.ToString();

        // Set the size of the text
        transform.localScale = new Vector3(size, size, size);
    }
}