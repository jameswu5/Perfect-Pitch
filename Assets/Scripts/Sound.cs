using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public const int SampleRate = 44100;
    public const int A4 = 440;
    public const int Duration = 1;

    public static float GetFrequency(int note) => Mathf.Pow(2, (note - 48) / 12f) * A4;

    private static float GetSineWave(int index, float frequency) => Mathf.Sin(2 * Mathf.PI * (index / (float)SampleRate) * frequency);

    private static float[] GetSamples(IEnumerable<int> notes)
    {
        int numberOfSamples = SampleRate * Duration;
        float[] samples = new float[numberOfSamples];
        for (int i = 0; i < numberOfSamples; i++)
        {
            float value = 0;
            foreach (int note in notes)
            {
                value += GetSineWave(i, GetFrequency(note));
            }
            samples[i] = value;
        }

        return samples;
    }

    public void PlaySound(float[] samples)
    {
        AudioClip audioClip = AudioClip.Create("Sound", samples.Length, 1, SampleRate, false);
        audioClip.SetData(samples, 0);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void Play(IEnumerable<int> notes)
    {
        float[] samples = GetSamples(notes);
        PlaySound(samples);
    }

    public void Play(bool[] noteArray)
    {
        List<int> notes = new();
        for (int i = 0; i < noteArray.Length; i++)
        {
            if (noteArray[i])
            {
                notes.Add(i);
            }
        }

        Play(notes);
    }

}
