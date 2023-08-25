using System;
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
    public Sound sound;

    public bool[] answer;
    public bool answerShown;

    private void Start()
    {
        score = 0;
        level = 1;
        octaves = 2;

        scoreText.text = $"Score: {score}";
        levelText.text = level.ToString();
        octaveText.text = octaves.ToString();

        CreateLevel();
        sound.Play(answer);
    }

    public void IncrementScore()
    {
        if (!answerShown)
        {
            score++;
            scoreText.text = $"Score: {score}";
        }
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


    public void CreateLevel()
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

        answer = notes;
        answerShown = false;
    }

    public void Submit()
    {
        bool[] submitted = piano.selectedKeys;
        if (CheckAnswer(submitted, answer))
        {
            IncrementScore();
            CreateLevel();
        }
        piano.Clear();
        sound.Play(answer);
    }

    public void Replay()
    {
        sound.Play(answer);
    }

    public void ShowAnswer()
    {
        for (int i = 0; i < answer.Length; i++)
        {
            if (answer[i])
            {
                piano.keys[i].SetAnswerColour();
            }
        }

        answerShown = true;
    }

    private static bool CheckAnswer(bool[] submitted, bool[] answer)
    {
        if (submitted.Length != answer.Length)
        {
            throw new Exception($"Submitted {submitted.Length} and answer {answer.Length} lengths do not match");
        }

        for (int i = 0; i < submitted.Length; i++)
        {
            if (submitted[i] != answer[i])
            {
                return false;
            }
        }

        return true;
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
