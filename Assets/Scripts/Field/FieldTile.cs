using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldTile : MonoBehaviour {
  public Sprite[] Sprites;
  public bool Harvestable = false;
  public int GrowthState = 0;

  private float _timerMin = 1f;
  private float _timerMax = 2f;
  private float _nextGrowthTimer = 0f;
  private float _growthTimer = 0f;
  private int _maxGrowth = 3;
  private SpriteRenderer _spriteRenderer;

  void Start() {
    _spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void Update() {
    _spriteRenderer.sprite = Sprites[GrowthState];
  }

  public void Grow(float time) {
    if (!Harvestable) {
      _growthTimer += time;
      if (_growthTimer >= _nextGrowthTimer) {
        GrowthState += 1;
        _growthTimer = 0f;
        _nextGrowthTimer = Random.Range(_timerMin, _timerMax);
        if (GrowthState >= _maxGrowth) {
          Harvestable = true;
          GrowthState = _maxGrowth;
        }
      }
    }
  }

  // Harvest tile and reset states.
  public void Harvest() {
    if (Harvestable) {
      GrowthState = 0;
      Harvestable = false;
      _nextGrowthTimer = Random.Range(_timerMin, _timerMax);
      GameObject.Find("Character").GetComponent<Character>().ChangeResource(transform.name, 1);
    }
  }
}
