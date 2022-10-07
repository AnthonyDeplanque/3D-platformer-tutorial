using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public int playerCoin = 0;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "coin")
    {
      Destroy(other.gameObject);
      playerCoin++;
    }
  }
}
