using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public int playerCoin = 0;
  private float playerJumpForce;
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

  private void OnControllerColliderHit(ControllerColliderHit hit)
  {
    if (hit.gameObject.tag == "hurt")
    {
      print("aie!");
    }
    if (hit.gameObject.tag == "mob")
    {
      playerJumpForce = GetComponent<PlayerController>().getJumpForce();
      GetComponent<PlayerController>().setMoveDirection(new Vector3(0, playerJumpForce, 0));
      Destroy(hit.gameObject.transform.parent.gameObject, .5f);
    }
  }
}