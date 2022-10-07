using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassAnim : MonoBehaviour
{
  public Vector3 amount;
  public float time;
  // Start is called before the first frame update
  void Start()
  {
    float randomTime = Random.Range(time - 0.6f, time + 0.6f);
    iTween.PunchScale(gameObject, iTween.Hash(
        "amount", amount,
        "time", time,
        "looptype", iTween.LoopType.loop
    ));
  }

}
