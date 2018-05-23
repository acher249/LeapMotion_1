using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Giavapps.MIDI;

public class InitializeRTMidi : MonoBehaviour
{

    void Awake()
    {
        RtMidi.Initialize();//Initializes RtMidi
    }
    void Update()
    {
        //Other function calls could be here or you can start a Coroutine for best performance!
    }

    void OnApplicationQuit()
    {
        RtMidi.Deinitialize();//Deinitializes RtMidi
    }

}