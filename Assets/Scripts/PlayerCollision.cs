using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public int playerCoin = 0;
  public GameObject pickupParticle;
  public GameObject mobParticle;
  private PlayerController playerController;
  private bool canInstantiateParticles = true;
  private float playerJumpForce;
  public GameObject cam1;
  public GameObject cam2;

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
      GameObject particles = Instantiate(pickupParticle, other.transform.position, Quaternion.identity);
      Destroy(particles, .5f);
      Destroy(other.gameObject);
      playerCoin++;
    }
    if (other.gameObject.tag == "Cam1")
    {
      cam1.SetActive(true);
    }
    if (other.gameObject.tag == "Cam2")
    {
      cam2.SetActive(true);
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Cam1")
    {
      cam1.SetActive(false);
    }
    if (other.gameObject.tag == "Cam2")
    {
      cam2.SetActive(false);
    }
  }
  private void OnControllerColliderHit(ControllerColliderHit hit)
  {

    playerJumpForce = playerController.getJumpForce();
    if (hit.gameObject.tag == "hurt")
    {
      print("aie!");
    }
    if (hit.gameObject.tag == "mob" && canInstantiateParticles)
    {
      canInstantiateParticles = false;
      playerController.setMoveDirection(new Vector3(0, playerJumpForce, 0));

      Vector3 size = hit.gameObject.transform.parent.gameObject.GetComponent<Transform>().localScale;
      iTween.PunchScale(hit.gameObject.transform.parent.gameObject, new Vector3(size.x / 2, size.y * 3, size.z / 2), 0.5f);
      GameObject particles = Instantiate(mobParticle, hit.transform.position, Quaternion.identity);
      Destroy(particles, .6f);
      StartCoroutine(resetInstatiation());
      Destroy(hit.gameObject.transform.parent.gameObject, .5f);
    }
  }

  // coroutine
  IEnumerator resetInstatiation()
  {
    yield return new WaitForSeconds(.3f);
    canInstantiateParticles = true;
  }
}