using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
  public GameObject inttext;
  public bool toggle = true, interactable;
  void OnTriggerStay(Collider other)
  {
    if(other.CompareTag("PlayerCamera"))
    {
        inttext.SetActive(true);
        interactable = true;
    }
  }

  void OnTriggerExit(Collider other)
  {
    if(other.CompareTag("FirstPersonController"))
    {
        inttext.SetActive(false);
        interactable = false;
    }
  }

}
