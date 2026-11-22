using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}