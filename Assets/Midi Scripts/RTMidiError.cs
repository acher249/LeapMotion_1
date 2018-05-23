using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Giavapps.MIDI;

public class RTMidiError : MonoBehaviour
{

    void Awake()
    {
        RtMidi.Initialize();//Initializes RtMidi
        RtMidi.Error.ManualChecking(true);//Enables manual checking of error messages
        RtMidi.Input.Device.Open(2);//Opens the third MIDI Input Device ("Oxygen 49" MIDI Keyboard in my case)
    }
    void Update()
    {

        //Check for error messages
        ulong errors = RtMidi.Error.Count();
        for (ulong e = 0; e < errors; e++)
        {
            Debug.Log(RtMidi.Error.String(e));//Prints an error message
        }
        //Checks if space key is pressed 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RtMidi.Input.Device.Open(2);//Ops! This causes an error!
        }

    }

    void OnApplicationQuit()
    {
        RtMidi.Deinitialize();//Deinitializes RtMidi
    }

}