using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Giavapps.MIDI;

public class RecieveInputMidiMessage : MonoBehaviour
{

    void Awake()
    {
        RtMidi.Initialize();//Initializes RtMidi
        RtMidi.Input.Device.Open(2);//Opens the third MIDI Input Device ("Oxygen 49" MIDI Keyboard in my case)
        RtMidi.Output.Device.Open(0);//Opens the first MIDI Output Device ("Microsoft GS Wavetable Synth" by default on Windows)
        RtMidi.Input.Device.AutoMessage(true);//Sends all received MIDI Input Messages to the MIDI Output Device ("Oxygen 49" >>> "Microsoft GS Wavetable Synth" in my case)
        RtMidi.Input.Message.ManualChecking(true);//Enables manual checking of MIDI Messages 
        RtMidi.Input.Message.Type(true, true, true);//Enables all MIDI Messages Types

    }
    void Update()
    {


        //Prints all received MIDI Messages
        ulong messages = RtMidi.Input.Message.Count();
        for (ulong m = 0; m < messages; m++)
        {
            double time = RtMidi.Input.Message.Time(m);
            ulong size = RtMidi.Input.Message.Size(m);
            string bytes = ""; 

            for (ulong b = 0; b < size; b++)
            {
                bytes += RtMidi.Input.Message.Byte(m, b).ToString() +" ";
            }

            Debug.Log("MIDI MESSAGE – TIME: "+time.ToString() + " – " +size.ToString() + bytes + " - " + bytes);
        }

    }

    void OnApplicationQuit()
    {
        RtMidi.Deinitialize();//Deinitializes RtMidi
    }

}