using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    System.Random rng = new();

    public int score;
    public int level;
    public int octaves;

    public Text octaveText;
    public Text levelText;
    public Text scoreText;

    public Piano piano;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        level = 1;
        octaves = 2;

        scoreText.text = score.ToString();
        levelText.text = level.ToString();
        octaveText.text = octaves.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void IncreaseLevel()
    {
        level++;
        levelText.text = level.ToString();
    }

    public void DecreaseLevel()
    {
        if (level > 1)
        {
            level--;
            levelText.text = level.ToString();
        }
    }

    public void IncreaseOctaveRange()
    {
        if (octaves < 4)
        {
            octaves++;
            octaveText.text = octaves.ToString();
        }
    }

    public void DecreaseOctaveRange()
    {
        if (octaves > 1)
        {
            octaves--;
            octaveText.text = octaves.ToString();
        }
    }


    public bool[] CreateLevel()
    {
        bool[] notes = new bool[Piano.NumberOfKeys];
        int notesLeft = level;

        int[] range = GetRange(octaves);
        int lowerBound = range[0];
        int upperBound = range[1];

        while (notesLeft > 0)
        {
            int note = rng.Next(lowerBound, upperBound + 1);
            if (notes[note] == false)
            {
                notes[note] = true;
                notesLeft--;
            }
        }

        return notes;
    }


    private static int[] GetRange(int octaveRange)
    {
        if (octaveRange < 1 || octaveRange > 4)
        {
            throw new Exception($"octaveRange {octaveRange} must be between 1 and 4.");
        }

        int l = octaveRange == 4 ? Piano.C3 : Piano.C4;
        int r;

        if (octaveRange == 1)
        {
            r = Piano.C5;
        }
        else if (octaveRange == 2)
        {
            r = Piano.C6;
        }
        else
        {
            r = Piano.C7;
        }

        return new int[] { l, r };
    }

}
