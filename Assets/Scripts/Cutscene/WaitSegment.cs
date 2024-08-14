using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaitSegment", menuName = "Cutscenes/Wait Segment")]
public class WaitSegment : CutsceneSegment {
  public float Duration;

  public override IEnumerator Execute() {
    yield return new WaitForSeconds(Duration);
  }
}