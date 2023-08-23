using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public int octaves;
    public GameObject key;


    public void Initialise(int octaves)
    {
        this.octaves = octaves;
    }
}
