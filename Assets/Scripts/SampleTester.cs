using UnityEngine;
using AudioFramework;
using UnityEngine.UI;

public class SampleTester : MonoBehaviour
{
    [SerializeField] private Button playBGMMusicBtn;
    [SerializeField] private Button playBMG2MusicBtn;
    [SerializeField] private Button playUISoundBtn;
    [SerializeField] private Button playSFXBtn;
    [SerializeField] private Button playVoiceBtn;
    [SerializeField] private Button playAmbientBtn;

    private void Start()
    {
        AudioManager.PlayMusic("MainTheme");

        AudioManager.FadeInAmbient("Forest", 1f);

        AudioManager.SetMusicVolume(0.7f);
        AudioManager.SetMusicVolume(0.8f);
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
