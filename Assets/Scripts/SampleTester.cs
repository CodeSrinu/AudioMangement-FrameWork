using UnityEngine;
using AudioFramework;
using UnityEngine.UI;

public class SampleTester : MonoBehaviour
{
    [Header("BGM Buttons")]
    [SerializeField] private Button playMusicBtn;
    [SerializeField] private Button mainThemeFadeInBtn;
    [SerializeField] private Button fastBeatFadeInBtn;
    [SerializeField] private Button stopMusicBtn;
    [SerializeField] private Button pauseMusicBtn;
    [SerializeField] private Button resumeMusicBtn;
    [SerializeField] private Button crossFadeToFastBeatBtn;
    [SerializeField] private Button musicFadeOutBtn;

    [Header("Ambient Buttons")]
    [SerializeField] private Button playAmbientBtn;
    [SerializeField] private Button stopAllAmbientBtn;
    [SerializeField] private Button ambientFadeInBtn;
    [SerializeField] private Button ambientFadeOutBtn;

    [Header("Other Buttons")]
    [SerializeField] private Button playRisingSFXBtn;
    [SerializeField] private Button playRisingAfter2SecBtn;
    [SerializeField] private Button playButtonClickBtn;
    [SerializeField] private Button playWelcomeBtn;

    [Header("Volume Sliders")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider ambienceVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider uiVolumeSlider;
    [SerializeField] private Slider voiceVolumeSlider;

    private void Start()
    {

        mainThemeFadeInBtn.onClick.AddListener(() => AudioManager.FadeInMusic("MainTheme", 2f));
        playMusicBtn.onClick.AddListener(() => AudioManager.PlayMusic("MainTheme"));
        fastBeatFadeInBtn.onClick.AddListener(() => AudioManager.FadeInMusic("FastBeat", 2f));
        stopMusicBtn.onClick.AddListener(() => AudioManager.StopMusic());
        pauseMusicBtn.onClick.AddListener(() => AudioManager.PauseMusic());
        resumeMusicBtn.onClick.AddListener(() => AudioManager.ResumeMusic());
        crossFadeToFastBeatBtn.onClick.AddListener(() => AudioManager.CrossFadeMusic("FastBeat", 5f));
        musicFadeOutBtn.onClick.AddListener(() => AudioManager.FadeOutMusic(2f));


        playAmbientBtn.onClick.AddListener(() => AudioManager.FadeInAmbient("Forest", 2f));
        stopAllAmbientBtn.onClick.AddListener(() => AudioManager.StopAllAmbient());
        ambientFadeInBtn.onClick.AddListener(() => AudioManager.FadeInAmbient("Forest", 2f));
        ambientFadeOutBtn.onClick.AddListener(() => AudioManager.FadeOutAmbient("Forest", 2f));


        playRisingSFXBtn.onClick.AddListener(() => AudioManager.PlaySFX("Rising"));
        playRisingAfter2SecBtn.onClick.AddListener(() => AudioManager.PlaySFXDelayed("Rising", 2f));
        playButtonClickBtn.onClick.AddListener(() => AudioManager.PlayUISound("ButtonClick"));
        playWelcomeBtn.onClick.AddListener(() =>
        {
            AudioManager.PlayVoice("Welcome");
        });

        musicVolumeSlider.onValueChanged.AddListener(v => AudioManager.SetMusicVolume(v));
        ambienceVolumeSlider.onValueChanged.AddListener(v => AudioManager.SetAmbientVolume(v));
        sfxVolumeSlider.onValueChanged.AddListener(v => AudioManager.SetSFXVolume(v));
        uiVolumeSlider.onValueChanged.AddListener(v => AudioManager.SetUIVolume(v));
        voiceVolumeSlider.onValueChanged.AddListener(v => AudioManager.SetVoiceVolume(v));

        ambienceVolumeSlider.value = 1f;
        musicVolumeSlider.value = 1f;
        sfxVolumeSlider.value = 1f;
        voiceVolumeSlider.value = 1f;
        uiVolumeSlider.value = 1f;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //        AudioManager.PlaySFX("Rising");

    //    if (Input.GetKeyDown(KeyCode.V))
    //        AudioManager.PlayVoice("Welcome");

    //    if (Input.GetKeyDown(KeyCode.C))
    //        AudioManager.CrossFadeMusic("FastBeat", 5f);

    //    if (Input.GetKeyDown(KeyCode.Space))
    //        AudioManager.FadeOutAmbient("Forest", 2f);

    //    if (Input.GetKeyDown(KeyCode.M))
    //        AudioManager.SetMusicVolume(0f);

    //    if (Input.GetKeyDown(KeyCode.U))
    //        AudioManager.SetMusicVolume(1f);

    //    if (Input.GetKeyDown(KeyCode.I))
    //        AudioManager.FadeInMusic("MainTheme", 2f);

    //    if (Input.GetKeyDown(KeyCode.O))
    //        AudioManager.FadeOutMusic(2f);
    //}
}