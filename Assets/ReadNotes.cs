using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

namespace SojaExiles
{
    public class ReadNotes : MonoBehaviour
    {
        public Transform player;
        public GameObject noteUI;

        public GameObject pickUpText;
        public float dist;
        //public AudioSource pickUpSound;

        public bool inReach;


        void Start()
        {
            noteUI.SetActive(false);
            pickUpText.SetActive(false);

            inReach = false;
        }



        void Update()
        {

            dist = Vector3.Distance(player.position, transform.position);
            if (dist < 2)
            {
                inReach = true;
                pickUpText.SetActive(true);

            }

            if (dist > 2)
            {
                inReach = false;
                pickUpText.SetActive(false);
            }

            if (Input.GetKey("e") && inReach)
            {
                noteUI.SetActive(true);
            }

        }


        public void ExitButton()
        {

            noteUI.SetActive(false);
            inReach = false;
            pickUpText.SetActive(false);

        }
    }
}