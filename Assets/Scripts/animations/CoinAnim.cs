using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinAnim : MonoBehaviour
{
  public Vector3 direction;
  private Vector3 initialPosition;

  private Vector3 newPosition;
  private float upAndDown = 0.01f;


  // Start is called before the first frame update
  void Start()
  {
    initialPosition = gameObject.transform.position;
  }

  // Update is called once per frame
  void Update()
  {

    gameObject.transform.Rotate(direction * Time.deltaTime);

    if (gameObject.tag == "coin")
    {
      gameObject.transform.position += new Vector3(0, upAndDown, 0);
      if (gameObject.transform.position.y >= initialPosition.y + 1 || gameObject.transform.position.y <= initialPosition.y)
      {
        upAndDown *= -1;
      }
    }
  }
}
