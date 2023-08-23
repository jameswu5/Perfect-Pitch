using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public int octave;
    public int note;
    public SpriteRenderer sr;

    public void Initialise(int octave, int note)
    {
        this.octave = octave;
        this.note = note;
    }


    private void OnMouseDown()
    {
        Debug.Log(this);
    }

    public override string ToString()
    {
        return $"{Note.GetNote(note)}{octave}";
    }
}
