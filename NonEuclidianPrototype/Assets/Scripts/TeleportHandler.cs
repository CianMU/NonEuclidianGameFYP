using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject pairedTeleporter;
    private Transform pairedTeleporterTransform;
    [SerializeField]
    private GameObject teleportee;
    private CharacterController controller;
    private bool allowTeleport;
    // Start is called before the first frame update
    void Start()
    {
        pairedTeleporterTransform = pairedTeleporter.transform;
        controller = teleportee.GetComponent<CharacterController>();
        allowTeleport = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == teleportee && allowTeleport == true)
        {
            pairedTeleporter.GetComponent<TeleportHandler>().allowTeleport = false;
            Teleport();
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        allowTeleport = true;
    }

    private void Teleport()
    {
        controller.enabled = false;
        teleportee.transform.position += (pairedTeleporter.transform.position - teleportee.transform.position) - (this.gameObject.transform.position - teleportee.transform.position);
        controller.enabled = true;
        

    }
}
