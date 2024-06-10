using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour {
  private SpriteRenderer _spriteRenderer;
  private Color _originalColor;
  private float _transparencyLevel = 0.6f;

  void Start() {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    if(_spriteRenderer == null) {
      Debug.LogError("Transparency: No SpriteRenderer found on the GameObject.");
    }
    _originalColor = _spriteRenderer.color;
  }

  void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.name == "Character" && other is BoxCollider2D) {
      _spriteRenderer.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b, _transparencyLevel);
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if(other.gameObject.name == "Character" && other is BoxCollider2D) {
      _spriteRenderer.color = _originalColor;
    }
  }
}
