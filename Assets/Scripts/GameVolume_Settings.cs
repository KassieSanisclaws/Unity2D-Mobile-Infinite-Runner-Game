using UnityEngine;
using UnityEngine.Audio; // This is the namespace for the Audio Mixer
using UnityEngine.UI; // This is the namespace for the UI elements like 'Slider

public class GameVolume_Settings : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer; // This is the Audio Mixer object
    [SerializeField] private Slider musicSlider; // This is the Slider object
    [SerializeField] private Slider sfxSlider; // This is the Slider object

    // Run Music when the game starts:
    private void Start()
    {
       SetMusicVolume();
    } 


   // Function Set Music Volume
   public void SetMusicVolume()
    {
      // Get the slider value:
       float volume = musicSlider.value;
       audioMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }

    // Function Set SFX Volume
    public void SetSFXVolume()
    {
        // Get the slider value:
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
