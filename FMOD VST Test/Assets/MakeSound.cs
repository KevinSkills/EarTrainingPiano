using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MakeSound : MonoBehaviour
{

    FMOD.System sys;
    FMOD.DSP dsp;
    public StudioEventEmitter see;

    // Start is called before the first frame update
    void Start()
    {

        
        FMOD.Factory.System_Create(out sys);

        uint handle;

        FMOD.ChannelGroup channelgroup_Master;
        

        sys.loadPlugin(Application.dataPath + "/Assets/Plugins/FMOD/lib/RoomPianov3.dll", out handle);

        sys.createDSPByPlugin(handle, out dsp);

        sys.getMasterChannelGroup(out channelgroup_Master);

        FMOD.Channel channel;

        sys.playDSP(dsp, channelgroup_Master, false, out channel);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) see.Play();

        
    }
}
