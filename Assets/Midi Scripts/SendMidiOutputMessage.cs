using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Giavapps.MIDI;

public class SendMidiOutputMessage : MonoBehaviour
{

    void Awake()
    {
        RtMidi.Initialize();///Initializes RtMidi
        RtMidi.Output.Device.Open(0);//Opens the first MIDI Output Device ("Microsoft GS Wavetable Synth" by default on Windows)

        //var dev = RtMidi.Output.Device.Open(1);
        //Debug.Log(dev);


    }


    public void OnClick()
    {
        RtMidi.Output.Message.Clear();//Clears the MIDI Message buffer
        RtMidi.Output.Message.Byte(144);//Adds one byte to the MIDI Message buffer
        RtMidi.Output.Message.Byte(60);//Adds one byte to the MIDI Message buffer
        RtMidi.Output.Message.Byte(100);//Adds one byte to the MIDI Message buffer
        RtMidi.Output.Message.Send();//Sends the MIDI Message to the MIDI Output Device

        Debug.Log("This got clicked.. Send Midi");
    }

    void OnApplicationQuit()
    {
        RtMidi.Deinitialize();//Deinitializes RtMidi
    }

}