using UnityEngine;
using UnityEngine.UI;

public class SoundSliderController : MonoBehaviour
{
    public Slider SoundSlider;

    public void Start()
    {
        SoundSlider.value = AudioListener.volume;
    }
    

    public void SetVolumeLevel()
    {
        AudioListener.volume = SoundSlider.value;
    }
}
