using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class afjipojlslsr : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public AudioSource backgroundMusic;

    private const string MasterVolumeKey = "MasterVolume";


    void Start()
    {

        float masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.5f);


        audioMixer.SetFloat("Master", masterVolume);


        if (masterSlider != null) masterSlider.value = masterVolume;



        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    public void OnMasterSliderValueChanged(float value)
    {

        audioMixer.SetFloat("Master", value);
        PlayerPrefs.SetFloat(MasterVolumeKey, value);
    }

}
