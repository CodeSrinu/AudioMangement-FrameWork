using UnityEngine;

namespace AudioFramework
{
    public class VoicePlayer
    {
        private AudioSource _audioSource;
        private MixerController _mixerController;

        public VoicePlayer(AudioSource audioSource, MixerController mixerController)
        {
            _audioSource = audioSource;
            _audioSource.outputAudioMixerGroup = mixerController.GetGroup("Voice");
        }

        public void PlayVoice(AudioClip clip)
        {
            if (_audioSource.isPlaying) 
                _audioSource.Stop();

            _audioSource.PlayOneShot(clip);
        }
    }
}
