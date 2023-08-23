using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int octave;
    public int note;
    private int id;
    private bool isWhiteKey;
    private Color originalColour;
    private Color highlightColour;
    private SpriteRenderer sr;

    private Piano piano;

    private bool selected;

    private void Start()
    {
        isWhiteKey = Note.IsWhiteKey(note);
        originalColour = isWhiteKey ? Colour.White : Colour.Black;
        highlightColour = isWhiteKey ? Colour.LightGrey : Colour.DarkGrey;
        sr = isWhiteKey ? gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>() : gameObject.GetComponent<SpriteRenderer>();
        selected = false;
        id = octave * 12 + note - 1;
        piano = transform.parent.parent.GetComponent<Piano>();
    }

    private void OnMouseDown()
    {
        sr.color = selected ? originalColour : highlightColour;
        selected = !selected;
        piano.ToggleKey(id);
        Debug.Log(this);
    }

    public override string ToString()
    {
        return $"{Note.GetNote(note)}{octave}";
    }
}
