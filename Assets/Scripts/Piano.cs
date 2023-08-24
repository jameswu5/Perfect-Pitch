using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public const int NumberOfKeys = 88;
    public bool[] selectedKeys;
    public Key[] keys;
    public Sound sound;

    public const int C3 = 27;
    public const int C4 = 39;
    public const int C5 = 51;
    public const int C6 = 63;
    public const int C7 = 75;

    private void Start()
    {
        keys = new Key[NumberOfKeys];
        InitialiseKeys();
        selectedKeys = new bool[NumberOfKeys];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Clear();
        }
    }

    private void InitialiseKeys()
    {
        int octaves = gameObject.transform.childCount;
        for (int i = 0; i < octaves; i++)
        {
            Transform octave = gameObject.transform.GetChild(i);
            int n = octave.childCount;
            for (int j = 0; j < n; j++)
            {
                Key key = octave.GetChild(j).GetComponent<Key>();
                keys[key.id] = key;
            }
        }
    }

    public void ToggleKey(int keyID)
    {
        selectedKeys[keyID] = !selectedKeys[keyID];
    }

    public void Clear()
    {
        Array.Clear(selectedKeys, 0, selectedKeys.Length);

        for (int i = 0; i < NumberOfKeys; i++)
        {
            if (keys[i] != null)
            {
                keys[i].ResetColour();
            }
        }
    }
}
