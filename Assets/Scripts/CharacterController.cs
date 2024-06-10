using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
  private float _walkSpeed = 4f;
  private float _runSpeed = 6f;
  private float _currentSpeed;
  private Animator _animator;
  private string _lastDirection = "CharacterIdleFront";
  private bool _isGathering = false;
  private FieldTile _currentNearestTile = null;
  private List<FieldTile> nearbyTiles = new List<FieldTile>();

  void Start() {
    _animator = GetComponent<Animator>();
    _currentSpeed = _walkSpeed;
  }

  void Update() {
    Vector2 movement = new Vector2();
    if (!_isGathering) {
      // TODO: use unity mapping system
      if (Input.GetKey(KeyCode.W)) movement.y = 1;
      if (Input.GetKey(KeyCode.S)) movement.y = -1;
      if (Input.GetKey(KeyCode.A)) movement.x = -1;
      if (Input.GetKey(KeyCode.D)) movement.x = 1;

      if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {
        _currentSpeed = _runSpeed;
      } else {
        _currentSpeed = _walkSpeed;
      }

      HandleMovement(movement);
      HandleAnimation(movement);
    }

    UpdateNearestTile();
    if (Input.GetMouseButtonDown(0)) StartGathering();
  }

  void HandleMovement(Vector2 movement) {
    movement.Normalize();
    transform.Translate(movement * _currentSpeed * Time.deltaTime, Space.World);
  }

  void HandleAnimation(Vector2 movement) {
    string animationState = DetermineAnimationState(movement);
    if (!_animator.GetCurrentAnimatorStateInfo(0).IsName(animationState)) {
      _animator.Play(animationState);
    }
  }

  void StartGathering() {
    if (_currentNearestTile != null) {
      Vector2 toTile = _currentNearestTile.transform.position - transform.position;
      DetermineDirection(toTile);
    }
    _isGathering = true;
    string gatherAnimation = DetermineGatherAnimation();
    _animator.Play(gatherAnimation);
    StartCoroutine(EndGathering());
  }

  void DetermineDirection(Vector2 direction) {
    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
      _lastDirection = direction.x < 0 ? "CharacterWalkLeft" : "CharacterWalkRight";
    } else {
      _lastDirection = direction.y > 0 ? "CharacterWalkBack" : "CharacterWalkFront";
    }
  }

  IEnumerator EndGathering() {
    float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
    yield return new WaitForSeconds(animationLength * 0.5f);
    HarvestTile();
    yield return new WaitForSeconds(animationLength * 0.1f);
    _isGathering = false;
  }

  string DetermineGatherAnimation() {
    return "CharacterGather" + _lastDirection.Replace("CharacterWalk", "").Replace("CharacterIdle", "");
  }

  string DetermineAnimationState(Vector2 movement) {
    if (movement.magnitude > 0) {
      DetermineDirection(movement);
      if (_currentSpeed == _runSpeed) {
        return _lastDirection.Replace("Walk", "Run");
      }
    } else {
      _lastDirection = _lastDirection.Contains("Walk") ? _lastDirection.Replace("Walk", "Idle") : _lastDirection;
    }
    return _lastDirection;
  }

  void UpdateNearestTile() {
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
    FieldTile nearestTile = null;
    float minDistance = float.MaxValue;

    foreach (Collider2D collider in colliders) {
      FieldTile tile = collider.GetComponent<FieldTile>();
      if (tile != null && tile.Harvestable) {
        float distance = (tile.transform.position - this.transform.position).sqrMagnitude;
        if (distance < minDistance) {
          minDistance = distance;
          nearestTile = tile;
        }
      }
    }

    if (nearestTile != _currentNearestTile) {
      _currentNearestTile = nearestTile;
    }
  }

  void HarvestTile() {
    if (_currentNearestTile != null && _currentNearestTile.Harvestable) {
      _currentNearestTile.Harvest();
    }
  }
}
