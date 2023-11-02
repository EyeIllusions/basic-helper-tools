using UnityEngine;
using Pixelogic.helper;

namespace Pixelogic.Util
{
    [RequireComponent(typeof(Rigidbody))]
   
    public class interactPhysicsBased : MonoBehaviour, Iinteractable
    {
        public bool isPickedUp = false;
    
        Rigidbody rb;
        public float speed;
         float DefaultDist =2; //TODO: use this to set the distance for the cube when !iszUsingUserMadeDist!!!
        public bool isUsingUserMadeDist = false;
        public float DistanceToCam;
     
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            
        }
    

        // Update is called once per frame
        public void Interact()
        {
            isPickedUp = !isPickedUp;
            //if (!isUsingUserMadeDist) distanceToCam = (getDragPoint(getDistFromCam(Camera.main)) - transform.position).normalized;
            //initDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
        }
        private void Update()
        {


        }
        public void FixedUpdate()
        {
            if (isPickedUp) {
                if (!isUsingUserMadeDist)
                {

                    rb.AddForce((getDragPoint(DefaultDist) - transform.position).normalized * speed, ForceMode.Force);
                }
                else
                { 
                    rb.AddForce((getDragPoint(DistanceToCam) -transform.position ).normalized*speed, ForceMode.Force);
                }
            }
            }
        Vector3 getDragPoint(float dist)
        {
            return (Camera.main.transform.position + (Camera.main.transform.forward * dist));
        }
      public float getDistFromCam(Camera cam)
        {
          if(cam == null) cam = Camera.main;

            return Vector3.Distance(cam.transform.position,transform.position);

        }

    }
}