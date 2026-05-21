using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using SalvageCrew.Core;

namespace SalvageCrew.Audio
{
    public class AudioManager : MonoBehaviour, IService
    {
        [SerializeField] private AudioMixerGroup sfxGroup;
        [SerializeField] private AudioMixerGroup voiceGroup;
        [SerializeField] private AudioMixerGroup ambienceGroup;
        [SerializeField] private int poolSize = 16;

        private readonly Queue<AudioSource> _pool = new();
        private AudioSource _ambience, _voice;

        public void Register() => Services.Register(this);

        private void Awake()
        {
            for (int i = 0; i < poolSize; i++) _pool.Enqueue(New("OneShot_" + i, sfxGroup));
            _ambience = New("Ambience", ambienceGroup); _ambience.loop = true;
            _voice = New("Voice", voiceGroup);
        }

        private AudioSource New(string n, AudioMixerGroup g)
        {
            var go = new GameObject(n); go.transform.SetParent(transform, false);
            var s = go.AddComponent<AudioSource>();
            s.playOnAwake = false; s.outputAudioMixerGroup = g;
            return s;
        }

        public void PlayOneShot(AudioClip c, Vector3 pos, float vol = 1f)
        {
            if (c == null || _pool.Count == 0) return;
            var s = _pool.Dequeue();
            s.transform.position = pos; s.clip = c; s.volume = vol; s.spatialBlend = 1f; s.Play();
            _pool.Enqueue(s);
        }

        public void PlayAmbience(AudioClip c, float vol = 0.6f)
        {
            if (c == null) return;
            _ambience.clip = c; _ambience.volume = vol; _ambience.spatialBlend = 0f; _ambience.Play();
        }

        public void PlayVoice(AudioClip c, float vol = 1f)
        {
            if (c == null) return;
            _voice.clip = c; _voice.volume = vol; _voice.spatialBlend = 0f; _voice.Play();
        }
    }
}
