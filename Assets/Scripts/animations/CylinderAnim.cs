using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderAnim : MonoBehaviour
{
  public Vector3 direction;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(direction * Time.deltaTime);
  }
}
