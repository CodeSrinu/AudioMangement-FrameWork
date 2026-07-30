using UnityEngine;
using AudioFramework;
using UnityEngine.UI;

public class SampleTester : MonoBehaviour
{
    [SerializeField] private Button mainThemeFadeIn;
    [SerializeField] private Button fastBeatFadeInBtn;
    [SerializeField] private Button stopMusicBtn;
    [SerializeField] private Button pauseMusicBtn;
    [SerializeField] private Button resumeMusicBtn;
    [SerializeField] private Button crossFadeMusicBtn;
    [SerializeField] private Button playUISoundBtn;
    [SerializeField] private Button playSFXBtn;
    [SerializeField] private Button playVoiceBtn;
    [SerializeField] private Button playAmbientBtn;

    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider ambienceVolume;
    [SerializeField] private Slider sfxVolume;
    [SerializeField] private Slider voiceVolume;
    [SerializeField] private Slider uiVolume;

    private void Start()
    {
        

        mainThemeFadeIn.onClick.AddListener(() =>
        {
            AudioManager.FadeInBGM("MainTheme", 2f);
        });
        fastBeatFadeInBtn.onClick.AddListener(() =>
        {
            AudioManager.FadeInBGM("FastBeat", 2f);

        });
        stopMusicBtn.onClick.AddListener(() =>
        {
            AudioManager.StopMusic();

        });
        pauseMusicBtn.onClick.AddListener(() =>
        {
            AudioManager.PauseMusic();
        });
        resumeMusicBtn.onClick.AddListener(() =>
        {
            AudioManager.ResumeMusic();
        });
        crossFadeMusicBtn.onClick.AddListener(() =>
        {
            AudioManager.CrossFadeMusic("FastBeat", 5f);
        });
        playUISoundBtn.onClick.AddListener(() =>
        {
            AudioManager.PlayUI("ButtonClick");
        });
        playSFXBtn.onClick.AddListener(() =>
        {
            AudioManager.PlaySFX("Rising");
        });

        playVoiceBtn.onClick.AddListener(() =>
        {
            AudioManager.PlayVoice("Welcome");
        });

        playAmbientBtn.onClick.AddListener(() =>
        {
            AudioManager.FadeInAmbient("Forest", 2f);
        });
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.PlaySFX("Rising");
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManager.PlaySFX("ButtonClick");
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            AudioManager.PlayVoice("Welcome");
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            AudioManager.CrossFadeMusic("FastBeat" , 5f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.FadeOutAmbient("Forest", 2f);
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.SetMusicVolume(0);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            AudioManager.SetMusicVolume(1);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            AudioManager.FadeInBGM("MainTheme", 2f);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            AudioManager.FadeOutBGM(2f);
        }
    }
}
