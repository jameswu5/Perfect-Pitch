using UnityEngine;

public class Key : MonoBehaviour
{
    public int octave;
    public int note;
    public int id;
    private bool isWhiteKey;
    private Color originalColour;
    private Color highlightColour;
    private Color answerColour;
    private SpriteRenderer sr;
    private Piano piano;
    private bool selected;

    private void Start()
    {
        isWhiteKey = Note.IsWhiteKey(note);
        originalColour = isWhiteKey ? Colour.White : Colour.Black;
        highlightColour = isWhiteKey ? Colour.LightGrey : Colour.DarkGrey;
        answerColour = isWhiteKey ? Colour.LightYellow : Colour.DarkYellow;
        sr = isWhiteKey ? gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>() : gameObject.GetComponent<SpriteRenderer>();
        selected = false;
        id = octave * 12 + note - 1;
        piano = transform.parent.parent.GetComponent<Piano>();
    }

    private void OnMouseDown()
    {
        sr.color = selected ? originalColour : highlightColour;
        selected = !selected;
        piano.ToggleKey(id, selected);
    }

    public void Reset()
    {
        sr.color = originalColour;
        selected = false;
    }

    public void SetAnswerColour() => sr.color = answerColour;

    public override string ToString() => $"{Note.GetNote(note)}{octave}";
}
