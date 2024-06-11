using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
  public AudioClip[] ambientSounds;
  public AudioClip[] stepSounds;
  public AudioClip[] harvestSounds;

  private AudioSource audioSource;

  private float _stepSoundTimer = 0f;
  private float _stepSoundDelay = 0.6f;

  void Start() {
    audioSource = GetComponent<AudioSource>();
    PlayAmbientSound();
  }

  void Update() {
    // TODO: Change ambient theme based on time of day
  }

  public void PlayStepSound() {
    int index = Random.Range(0, stepSounds.Length);
    audioSource.PlayOneShot(stepSounds[index]);
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

  public void PlayHarvestSound(float delay = 0f) {
    StartCoroutine(PlayHarvestSoundWithDelay(delay));
  }

  private IEnumerator PlayHarvestSoundWithDelay(float delay) {
    yield return new WaitForSeconds(delay);
    int index = Random.Range(0, harvestSounds.Length);
    audioSource.PlayOneShot(harvestSounds[index]);
  }

  public void PlayAmbientSound() {
    int index = Random.Range(0, ambientSounds.Length);
    audioSource.PlayOneShot(ambientSounds[index]);
  }
}
