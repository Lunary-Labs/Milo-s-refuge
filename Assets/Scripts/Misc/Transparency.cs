using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour {
  private SpriteRenderer _spriteRenderer;
  private Color _originalColor;
  private float _transparencyLevel = 0.6f;
  private float _fadeDuration = 0.5f;

  void Start() {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _originalColor = _spriteRenderer.color;
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Character") && other is BoxCollider2D) {
      StartCoroutine(FadeToTransparency(_transparencyLevel));
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Character") && other is BoxCollider2D) {
      StartCoroutine(FadeToTransparency(_originalColor.a));
    }
  }

  private IEnumerator FadeToTransparency(float targetAlpha) {
    float startAlpha = _spriteRenderer.color.a;
    float elapsedTime = 0f;
    while (elapsedTime < _fadeDuration) {
      elapsedTime += Time.deltaTime;
      float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / _fadeDuration);
      _spriteRenderer.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b, newAlpha);
      yield return null;
    }
    _spriteRenderer.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b, targetAlpha);
  }
}
