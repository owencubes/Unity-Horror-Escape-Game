using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
        public GameObject activatingOB;
        public Transform player;
        public GameObject pickUpText;
        public float dist; 
        //public AudioSource pickUpSound;

        public bool inReach;


        void Start()
        {
            player = GameObject.Find("FirstPersonController").transform;
            activatingOB.SetActive(false);
            pickUpText.SetActive(false);

            inReach = false;

        }

        void OnTriggerEnter(Collider other)
        {
            if (player)
            {
                dist = Vector3.Distance(player.position, transform.position);
                if (dist < 5)
                {
                    inReach = true;
                    pickUpText.SetActive(true);
                }
            }

        }

        void OnTriggerExit(Collider other)
        {

            float dist = Vector3.Distance(player.position, transform.position);
            if (dist > 5)
            {
                inReach = false;
                pickUpText.SetActive(false);
            }
        }

        void Update()
        {
            if (Input.GetKey("e") && inReach)
            {
                activatingOB.SetActive(true);
                pickUpText.SetActive(false);
            }

        }


        public void ExitButton()
        {

            activatingOB.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = true;
            inReach = false;
            pickUpText.SetActive(false);

        }
}
