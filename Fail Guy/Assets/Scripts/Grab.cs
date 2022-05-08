using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    [SerializeField]
    private float pickupRange;
    [SerializeField]
    private LayerMask pickupLayer;
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private float throwingForce;

    private Rigidbody currentObjRigid;
    private Collider currentObjCollider;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Ray pickupRay = new Ray(player.transform.position, player.transform.forward);

            if(Physics.Raycast(pickupRay, out RaycastHit hitInfo, pickupRange, pickupLayer)){
                if(currentObjRigid){
                    currentObjRigid.isKinematic = false;
                    currentObjCollider.enabled = true;

                    currentObjRigid = hitInfo.rigidbody;
                    currentObjCollider = hitInfo.collider;

                    currentObjRigid.isKinematic = true;
                    currentObjCollider.enabled = false;
                }
                else{
                    currentObjRigid = hitInfo.rigidbody;
                    currentObjCollider = hitInfo.collider;

                    currentObjRigid.isKinematic = true;
                    currentObjCollider.enabled = false;
                }
                return;
            }

            if(currentObjRigid){
                currentObjRigid.isKinematic = false;
                currentObjCollider.enabled = true;

                currentObjCollider = null;
                currentObjRigid = null;
            }

        }

        if(Input.GetKey(KeyCode.Q)){
            if(currentObjRigid){
                currentObjCollider.enabled = true;
                currentObjRigid.isKinematic = false;

                currentObjRigid.AddForce(player.transform.forward * throwingForce, ForceMode.Impulse);

                currentObjCollider = null;
                currentObjRigid = null;
            }
        }

        if(currentObjRigid){
            currentObjRigid.position = hand.position;
            currentObjRigid.rotation = hand.rotation;
        }

    }
}
