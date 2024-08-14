using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveCharacterSegment", menuName = "Cutscenes/Move Character Segment")]
public class MoveCharacterSegment : CutsceneSegment {
  public string TargetName;
  public Vector3 StartPoint;
  public Vector3 EndPoint;
  public float Speed;

  public override IEnumerator Execute() {
    GameObject target = GameObject.Find(TargetName);
    if (target == null) {
      Debug.LogError($"Target with name '{TargetName}' not found.");
      yield break;
    }

    Transform targetTransform = target.transform;
    targetTransform.position = StartPoint;
    float distance = Vector3.Distance(StartPoint, EndPoint);
    float duration = distance / Speed;
    float elapsedTime = 0;

    while (elapsedTime < duration) {
      targetTransform.position = Vector3.Lerp(StartPoint, EndPoint, elapsedTime / duration);
      elapsedTime += Time.deltaTime;
      yield return null;
    }
    targetTransform.position = EndPoint;
  }
}
