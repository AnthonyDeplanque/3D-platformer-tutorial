using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform target;
  private Vector3 offset;
  private Vector3 velocity = Vector3.zero;


  private float smoothTime = .3f;
  // Start is called before the first frame update
  void Start()
  {
    offset = target.position - transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 targetPosition = target.position - offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    // transform.LookAt(target);
  }
}
