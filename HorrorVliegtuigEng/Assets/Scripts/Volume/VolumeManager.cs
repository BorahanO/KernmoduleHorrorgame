using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public SoundScriptable volume;


    public void volumeUpdate(float val)
    {
        volume.Volume = val;
    }

    private void Update()
    {
        AudioListener.volume = volume.Volume;
    }
}
