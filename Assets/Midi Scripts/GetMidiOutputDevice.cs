using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Giavapps.MIDI;

public class GetMidiOutputDevice : MonoBehaviour
{

    void Awake()
    {
        RtMidi.Initialize();//Initializes RtMidi

        //Prints all available MIDI Input devices
        Debug.Log("MIDI INPUT DEVICES:");
        uint i;
        for (i = 0; i < RtMidi.Input.Device.Count(); i++)
        {
            Debug.Log(RtMidi.Input.Device.Name(i));
        }
        //Prints all available MIDI Output devices
        Debug.Log("MIDI OUTPUT DEVICES:");
        for (i = 0; i < RtMidi.Output.Device.Count(); i++)
        {
            Debug.Log(RtMidi.Output.Device.Name(i));
        }

        RtMidi.Input.Device.Open(2);//Opens the third MIDI Input Device ("Oxygen 49" MIDI Keyboard in my case)
        RtMidi.Output.Device.Open(0);//Opens the first MIDI Output Device ("Microsoft GS Wavetable Synth" by default on Windows)
        RtMidi.Input.Device.AutoMessage(true);//Sends all received MIDI Input Messages to the MIDI Output Device ("Oxygen 49" >>> "Microsoft GS Wavetable Synth" in my case)

    }

    void OnApplicationQuit()
    {
        RtMidi.Deinitialize();//Deinitializes RtMidi
    }

}