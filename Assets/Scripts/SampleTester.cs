using UnityEngine;
using AudioFramework;

public class SampleTester : MonoBehaviour
{
    [SerializeField] private AudioClip _bgmMusic;
    [SerializeField] private AudioClip _bgmMusic2;
    [SerializeField] private AudioClip _sfxSound;
    [SerializeField] private AudioClip _voiceClip;
    [SerializeField] private AudioClip _ambientSound;

    private void Start()
    {
        AudioManager.PlayMusic(_bgmMusic);

        AudioManager.FadeInAmbient(_ambientSound, "MainAmbient", 1f);

        AudioManager.SetMusicVolume(0.7f);
        AudioManager.SetMusicVolume(0.8f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.PlaySFX(_sfxSound);
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            AudioManager.PlayVoice(_voiceClip);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            AudioManager.CrossFadeMusic(_bgmMusic2 , 5f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.StopAllAmbient();
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
            AudioManager.FadeInBGM(_bgmMusic, 2f);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            AudioManager.FadeOutBGM(2f);
        }
    }
}
