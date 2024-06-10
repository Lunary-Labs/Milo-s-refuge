using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour {
  private float _walkSpeed = 2.5f;
  private float _runSpeed = 4f;
  private float _currentSpeed;
  private Rigidbody2D _rigidbody;
  private Animator _animator;
  private string _lastDirection = "CharacterIdleFront";
  private bool _isGathering = false;
  private FieldTile _currentNearestTile = null;
  private List<FieldTile> nearbyTiles = new List<FieldTile>();
  private Vector2 _movement = Vector2.zero;

  void Start() {
    _animator = GetComponent<Animator>();
    _rigidbody = GetComponent<Rigidbody2D>();
    _currentSpeed = _walkSpeed;
  }

  void FixedUpdate() {
    _rigidbody.MovePosition(_rigidbody.position + _movement.normalized * _currentSpeed * Time.fixedDeltaTime);
  }

  void Update() {
    _movement = Vector2.zero;
    if (!_isGathering) {
      // TODO: use unity mapping system instead of hard coded keys
      if (Input.GetKey(KeyCode.W)) _movement.y = 1;
      if (Input.GetKey(KeyCode.S)) _movement.y = -1;
      if (Input.GetKey(KeyCode.A)) _movement.x = -1;
      if (Input.GetKey(KeyCode.D)) _movement.x = 1;
      _currentSpeed = (Input.GetKey(KeyCode.LeftControl)) ? _runSpeed : _walkSpeed;
      HandleAnimation(_movement);
    }

    UpdateNearestTile();
    if (Input.GetMouseButtonDown(0)) StartGathering();
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
        float distance = (tile.transform.position - transform.position).sqrMagnitude;
        if (distance < minDistance) {
          minDistance = distance;
          nearestTile = tile;
        }
      }
    }

    _currentNearestTile = nearestTile;
  }

  void HarvestTile() {
    if (_currentNearestTile != null && _currentNearestTile.Harvestable) {
      _currentNearestTile.Harvest();
    }
  }
}
