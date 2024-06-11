using System.Collections;
using UnityEngine;

public class AudioControllerCharacter : MonoBehaviour {
  public AudioClip[] StepSounds;
  public AudioClip[] HarvestSounds;

  private AudioSource _audioSource;
  private float _stepSoundTimer = 0f;
  private float _stepSoundDelay = 0.6f;
  private float _harvestSoundDelay = 0.3f;

  void Start() {
    _audioSource = GetComponent<AudioSource>();
  }

  public void PlayHarvestSound() {
    StartCoroutine(PlayHarvestSoundWithDelay());
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
    int index = Random.Range(0, StepSounds.Length);
    _audioSource.PlayOneShot(StepSounds[index]);
  }

  private IEnumerator PlayHarvestSoundWithDelay() {
    yield return new WaitForSeconds(_harvestSoundDelay);
    int index = Random.Range(0, HarvestSounds.Length);
    _audioSource.PlayOneShot(HarvestSounds[index]);
  }
}
