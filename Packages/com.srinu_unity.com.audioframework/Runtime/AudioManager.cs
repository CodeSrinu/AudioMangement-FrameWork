using PlasticGui.WorkspaceWindow.Locks;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioFramework
{
    public class AudioManager: MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Mixer")]
        [SerializeField] private AudioMixer _mainMixer;

        [Header("SFX")]
        [SerializeField] private int _sfxSourcesCount;

        private MixerController _mixerController;
        private BGMPlayer _bgmPlayer;
        private SFXPool _sfxPool;
        private VoicePlayer _voicePlayer;
        private AmbientPlayer _ambientPlayer;

        private AudioSource _bgmSource1;
        private AudioSource _bgmSource2;
        private AudioSource _voiceSource;

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Initialize();
        }

        private void Initialize()
        {
            _mixerController = new MixerController(_mainMixer);


            _bgmSource1 = gameObject.AddComponent<AudioSource>();
            _bgmSource2 = gameObject.AddComponent<AudioSource>();
            _bgmPlayer = new BGMPlayer(
                _mixerController.GetGroup("BGM"),
                this
                );

            _bgmPlayer.SetSources(_bgmSource1, _bgmSource2);


            _sfxPool = new SFXPool(_sfxSourcesCount, this, _mixerController);


            _voiceSource = gameObject.AddComponent<AudioSource>();
            _voicePlayer = new VoicePlayer(_voiceSource, _mixerController);

            _ambientPlayer = new AmbientPlayer(_mixerController, this);

            LoadVolumes();
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
            Instance.SaveVolumes();
        }
        public static void SetSFXVolume(float vol)
        {
            Instance._mixerController.SetVolume("SFXVolume", vol);
            Instance.SaveVolumes();
        }
        public static void SetVoiceVolume(float vol)
        {
            Instance._mixerController.SetVolume("VoiceVolume", vol);
            Instance.SaveVolumes();

        }
        public static void SetAmbientVolume(float vol)
        {
            Instance._mixerController.SetVolume("AmbientVolume", vol);
            Instance.SaveVolumes();

        }


        public static float GetMusicVolume()
        {
            return Instance._mixerController.GetVolume("BGMVolume");
        }
        public static float GetSFXVolume()
        {
            return Instance._mixerController.GetVolume("SFXVolume");
        }
        public static float GetVoiceVolume()
        {
            return Instance._mixerController.GetVolume("VoiceVolume");
        }
        public static float GetAmbientVolume()
        {
            return Instance._mixerController.GetVolume("AmbientVolume");
        }



        public static void PlaySFX(AudioClip clip)
        {
            Instance._sfxPool.PlaySFX(clip);
        }
        public static void PlayDelayedSFX(AudioClip clip, float delay)
        {
            Instance._sfxPool.PlayDelayedSFX(clip, delay);
        }

        public static void PlayVoice(AudioClip voiceClip)
        {
            Instance._voicePlayer.PlayVoice(voiceClip);
        }

        public static void PlayAmbient(AudioClip clip, string ambientKey)
        {
            Instance._ambientPlayer.PlayAmbient(clip, ambientKey);
        }

        public static void StopAllAmbient()
        {
            Instance._ambientPlayer.StopAllAmbient();
        }

        public static void StopAmbientByKey(string ambientKey)
        {
            Instance._ambientPlayer.StopAmbientByKey(ambientKey);
        }

        public static void FadeInBGM(AudioClip clip, float fadeInTime)
        {
            Instance._bgmPlayer.FadeInBGM(clip, fadeInTime);
        }
        public static void FadeOutBGM(float fadeInTime)
        {
            Instance._bgmPlayer.FadeOutBGM(fadeInTime);
        }

        public static void FadeInAmbient(AudioClip clip,string ambientKey, float fadeInTime)
        {
            Instance._ambientPlayer.FadeInAmbient(clip, ambientKey, fadeInTime);
        }
        public static void FadeOutAmbient(string ambientKey, float fadeInTime)
        {
            Instance._ambientPlayer.FadeOutAmbient(ambientKey, fadeInTime);
        }


        private void SaveVolumes()
        {
            PlayerPrefs.SetFloat("BGMVolume", GetMusicVolume());
            PlayerPrefs.SetFloat("SFXVolume", GetSFXVolume());
            PlayerPrefs.SetFloat("VoiceVolume", GetVoiceVolume());
            PlayerPrefs.SetFloat("AmbientVolume", GetAmbientVolume());
        }

        private void LoadVolumes()
        {
            SetMusicVolume(PlayerPrefs.GetFloat("BGMVolume", 1f));
            SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", 1f));
            SetVoiceVolume(PlayerPrefs.GetFloat("VoiceVolume", 1f));
            SetAmbientVolume(PlayerPrefs.GetFloat("AmbientVolume", 1f));
        }
    }
}
