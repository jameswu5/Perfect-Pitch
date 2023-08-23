using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public const int NumberOfKeys = 88;
    public bool[] selectedKeys;

    private void Start()
    {
        selectedKeys = new bool[NumberOfKeys];
    }

    public void ToggleKey(int keyID)
    {
        selectedKeys[keyID] = !selectedKeys[keyID];
    }
}
