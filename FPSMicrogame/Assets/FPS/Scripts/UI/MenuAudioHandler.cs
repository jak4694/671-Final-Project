using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioHandler : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string UIClickSfx = "";

    [FMODUnity.EventRef]
    public string UIHoverSfx = "";

    [FMODUnity.EventRef]
    public string UIDragSfx = "";

    [FMODUnity.EventRef]
    public string PauseMenuSnapshot = "";
    public bool useSnapshot = true;
    private FMOD.Studio.EventInstance pauseSnapshot;

    private void Awake()
    {
        pauseSnapshot = FMODUnity.RuntimeManager.CreateInstance(PauseMenuSnapshot);
    }

    private void OnEnable()
    {
        if(useSnapshot)
        {
            pauseSnapshot.start();
        }
    }

    private void OnDisable()
    {
        if(useSnapshot)
        {
            pauseSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public void PlayClickSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(UIClickSfx);
    }

    public void PlayHoverSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(UIHoverSfx);
    }

    public void PlayDragSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(UIDragSfx);
    }
}
