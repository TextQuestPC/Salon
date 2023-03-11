
using Core;
using Localization;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : Window
{
    [Header("Header")]
    [SerializeField]
    private Text setingsHeaderText;
    [Header("Texts")]
    [SerializeField]
    private Text musicLabelText;
    [SerializeField]
    private Text soundLabelText;
    [SerializeField]
    private Text vibrationLabelText;
    [Header("Sliders")]
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider vibrationSlider;

    public virtual void OnStart()
    {
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
       // vibrationSlider.onValueChanged.AddListener(ChangeSoundVolume);
    }


    public void ChangeMusicVolume(float value)
    {
        AudioManager.Instance.ChangeMusicVolume(value);
    }
    public void ChangeSoundVolume(float value)
    {
        AudioManager.Instance.ChangeSoundVolume(value);
    }
    public override void ChangeLanguage()
    {
    //   musicLabelText.text = Localizator.GetTextUI("Music");
    //  soundLabelText.text = Localizator.GetTextUI("Sound");
    //  vibrationLabelText.text = Localizator.GetTextUI("Vibration");


    }

}
