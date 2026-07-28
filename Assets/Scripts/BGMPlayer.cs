using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioFramework
{
    public class BGMPlayer
    {
        private AudioMixerGroup _mixerGroup;
        private AudioSource _currentSource;
        private AudioSource _prevSource;
        private MonoBehaviour _coroutineRunner;

        public BGMPlayer(AudioMixerGroup mixerGroup, MonoBehaviour coroutineRunner)
        {
            _mixerGroup = mixerGroup;
            _coroutineRunner = coroutineRunner; 
        }

        public void SetSources(AudioSource currentSource, AudioSource prevSource)
        {
            _currentSource = currentSource;
            _prevSource = prevSource;
            _currentSource.outputAudioMixerGroup = _mixerGroup;
            _prevSource.outputAudioMixerGroup = _mixerGroup;
            _currentSource.loop = true;
            _prevSource.loop = true;
        }

        public void Play(AudioClip newClip)
        {
            if (newClip == _currentSource.clip) return;

            _currentSource.clip = newClip;
            _currentSource.Play();
        }

        public void Stop()
        {
            _currentSource?.Stop();
        }

        public void Pause()
        {
            _currentSource?.Pause();
        }

        public void Resume()
        {
            _currentSource.UnPause();
        }

        public void CrossFade(AudioClip clip, float fadeTime)
        {
            _coroutineRunner.StartCoroutine(CrossFadeRoutine(clip, fadeTime));
        }

        private IEnumerator CrossFadeRoutine(AudioClip newClip, float duration)
        {
            AudioSource temp = _currentSource;
            _currentSource = _prevSource;
            _prevSource = temp;

            _currentSource.clip = newClip;
            _currentSource.volume = 0f;
            _currentSource.Play();

            float timer = 0f;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                float t = timer / duration;
                _currentSource.volume = Mathf.Lerp(0f, 1f, t);
                _prevSource.volume = Mathf.Lerp(1f, 0f, t);

                yield return null;
            }

            _prevSource.Stop();

            _prevSource.volume = 1f;
            _currentSource.volume = 1f;
        }
    }
}
