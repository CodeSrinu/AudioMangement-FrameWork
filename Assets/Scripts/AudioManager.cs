using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioFramework
{
    public class AudioManager: MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Mixer")]
        [SerializeField] private AudioMixer _mainMixer;

        private MixerController _mixerController;
        private BGMPlayer _bgmPlayer;

        private AudioSource _bgmSource1;
        private AudioSource _bgmSource2;

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }

        public void Initialize()
        {
            _mixerController = new MixerController(_mainMixer);


            _bgmSource1 = gameObject.AddComponent<AudioSource>();
            _bgmSource2 = gameObject.AddComponent<AudioSource>();

            _bgmPlayer = new BGMPlayer(
                _mixerController.GetGroup("BGM"),
                this
                );

            _bgmPlayer.SetSources(_bgmSource1, _bgmSource2);
        }

        public static void PlayMusic(AudioClip clip)
        {
            Instance._bgmPlayer.Play(clip);
        }

        public static void StopMusic()
        {
            Instance._bgmPlayer.Stop();
        }

        public static void PauseMusic()
        {
            Instance._bgmPlayer.Pause();
        }

        public static void ResumeMusic()
        {
            Instance._bgmPlayer.Resume();
        }

        public static void CrossFadeMusic(AudioClip clip, float duration)
        {
            Instance._bgmPlayer.CrossFade(clip, duration);
        }

        public static void SetMusicVolume(float vol)
        {
            Instance._mixerController.SetVolume("BGMVolume", vol);
        }
        public static void SetSFXVolume(float vol)
        {
            Instance._mixerController.SetVolume("SFXVolume", vol);
        }
        public static void SetVoiceVolume(float vol)
        {
            Instance._mixerController.SetVolume("VoiceVolume", vol);
        }
        public static void SetAmbientVolume(float vol)
        {
            Instance._mixerController.SetVolume("AmbientVolume", vol);
        }

        public static void GetMusicVolume()
        {
            Instance._mixerController.GetVolume("BGMVolume");
        }
        public static void GetSFXVolume()
        {
            Instance._mixerController.GetVolume("SFXVolume");
        }
        public static void GetVoiceVolume()
        {
            Instance._mixerController.GetVolume("VoiceVolume");
        }
        public static void GetAmbientVolume()
        {
            Instance._mixerController.GetVolume("AmbientVolume");
        }
    }
}
