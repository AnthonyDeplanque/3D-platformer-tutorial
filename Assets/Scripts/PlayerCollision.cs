using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public int playerCoin = 0;
  private PlayerController playerController;

  private float playerJumpForce;

  // Start is called before the first frame update
  void Start()
  {
    playerController = GetComponent<PlayerController>();
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
    playerJumpForce = playerController.getJumpForce();
    if (hit.gameObject.tag == "hurt")
    {
      print("aie!");
    }
    if (hit.gameObject.tag == "mob")
    {
      playerController.setMoveDirection(new Vector3(0, playerJumpForce, 0));

      Vector3 size = hit.gameObject.transform.parent.gameObject.GetComponent<Transform>().localScale;
      iTween.PunchScale(hit.gameObject.transform.parent.gameObject, new Vector3(size.x / 2, size.y * 3, size.z / 2), 0.5f);
      Destroy(hit.gameObject.transform.parent.gameObject, .5f);
    }
  }
}