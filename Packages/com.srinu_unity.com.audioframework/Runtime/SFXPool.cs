using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioFramework
{
    public class SFXPool
    {
        private int _sfxSourcesCount = 10;
        private MonoBehaviour _coroutineRunner;
        private MixerController _mixerController;
        private List<AudioSource> _pool;



        public SFXPool(int sfxSourcesCount, MonoBehaviour coroutineRunner, MixerController mixerController)
        {
            _sfxSourcesCount = sfxSourcesCount;
            _coroutineRunner = coroutineRunner;
            _mixerController = mixerController;
            _pool = new List<AudioSource>();
            CreateAudioSources(sfxSourcesCount);
        }

        private void CreateAudioSources(int count)
        {
            for(int i = 0; i < count; i++)
            {
                AudioSource source = _coroutineRunner.gameObject.AddComponent<AudioSource>();
                source.outputAudioMixerGroup = _mixerController.GetGroup("SFX");
                source.playOnAwake = false;
                _pool.Add(source);
            }
        }


        private AudioSource GetAudioSource()
        {
            foreach(AudioSource source in _pool)
            {
                if(!source.isPlaying)
                    return source;
            }

            AudioSource newSource = _coroutineRunner.gameObject.AddComponent<AudioSource>();
            newSource.outputAudioMixerGroup = _mixerController.GetGroup("SFX");
            newSource.playOnAwake = false;
            _pool.Add(newSource);
            return newSource;
        }

        public void PlaySFX(AudioClip clip)
        {
            AudioSource source = GetAudioSource();
            source.playOnAwake = false;
            source.PlayOneShot(clip);
        } 

        public void PlayDelayedSFX(AudioClip clip, float delay)
        {
            _coroutineRunner.StartCoroutine(DelayedPlay(clip, delay));
        }

        private IEnumerator DelayedPlay(AudioClip clip, float delay)
        {
            yield return new WaitForSeconds(delay);
            PlaySFX(clip);
        }
    }
}
