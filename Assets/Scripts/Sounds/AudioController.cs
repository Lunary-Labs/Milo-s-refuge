using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
  public AudioClip[] dayAmbientSounds;
  public AudioClip[] nightAmbientSounds;
  public AudioClip[] stepSounds;
  public AudioClip[] harvestSounds;

  private AudioSource audioSource;

  private float _stepSoundTimer = 0f;
  private float _stepSoundDelay = 0.6f;

  private float _fadeDuration = 2f;

  // TODO: remove this
  public bool _isDay = false;
  private bool _isDayPlaying = false;

  void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  void Update() {
    if (!audioSource.isPlaying) {
      //TODO: CHeck for day/night and weather
      if (_isDay) {
        StartCoroutine(ChangeAmbientSound(dayAmbientSounds));
        _isDayPlaying = true;
      } else {
        StartCoroutine(ChangeAmbientSound(nightAmbientSounds));
        _isDayPlaying = false;
      }
    }

    if (_isDay && !_isDayPlaying) {
      StartCoroutine(ChangeAmbientSound(dayAmbientSounds));
      _isDayPlaying = true;
    } else if (!_isDay && _isDayPlaying) {
      StartCoroutine(ChangeAmbientSound(nightAmbientSounds));
      _isDayPlaying = false;
    }
  }

  public void PlayHarvestSound(float delay = 0f) {
    StartCoroutine(PlayHarvestSoundWithDelay(delay));
  }

  public void HandleStepSounds(bool isMoving) {
    if (isMoving) {
      _stepSoundTimer += Time.deltaTime;
      if (_stepSoundTimer >= _stepSoundDelay) {
        PlayStepSound();
        _stepSoundTimer = 0f;
      }
    } else {
      _stepSoundTimer = 0f;
    }
  }

  private void PlayStepSound() {
    int index = Random.Range(0, stepSounds.Length);
    audioSource.PlayOneShot(stepSounds[index]);
  }

  private IEnumerator PlayHarvestSoundWithDelay(float delay) {
    yield return new WaitForSeconds(delay);
    int index = Random.Range(0, harvestSounds.Length);
    audioSource.PlayOneShot(harvestSounds[index]);
  }

  private IEnumerator ChangeAmbientSound(AudioClip[] soundArray) {
    if (audioSource.isPlaying) {
      yield return StartCoroutine(FadeOut(_fadeDuration));
    }
    int index = Random.Range(0, soundArray.Length);
    audioSource.clip = soundArray[index];
    audioSource.Play();
    yield return StartCoroutine(FadeIn(_fadeDuration));
}

  IEnumerator FadeOut(float fadeDuration) {
    float startVolume = audioSource.volume;
    while (audioSource.volume > 0) {
      audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
      yield return null;
    }
    audioSource.Stop();
    audioSource.volume = startVolume;
  }

  IEnumerator FadeIn(float fadeDuration) {
    float startVolume = audioSource.volume;
    audioSource.volume = 0;
    audioSource.Play();
    while (audioSource.volume < startVolume) {
      audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
      yield return null;
    }
    audioSource.volume = startVolume;
  }
}
