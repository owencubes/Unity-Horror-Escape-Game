using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalDoor : MonoBehaviour
{
    public Animator openandclose;
    public bool open;
    public Transform Player;
    public GameObject Key;
    public GameObject winText;
    void Start()
    {
        Player = GameObject.Find("FirstPersonController").transform;
        open = false;
    }

    void OnMouseOver()
    {
        {
            if (Player)
            {
                if (Key.activeSelf)
                {
                    float dist = Vector3.Distance(Player.position, transform.position);
                    if (dist < 15)
                    {
                        if (open == false)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(opening());
                            }
                        }
                        else
                        {
                            if (open == true)
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    StartCoroutine(closing());
                                }
                            }

                        }

                    }
                }

            }

        }

    }

    IEnumerator opening()
    {
        winText.SetActive(true);
        print("you are opening the door");
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
