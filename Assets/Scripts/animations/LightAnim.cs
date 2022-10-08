using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnim : MonoBehaviour
{
  private Vector3 direction;
  void Start()
  {
    direction = new Vector3(0, .3f, 0);
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(direction * Time.deltaTime);
  }
}
