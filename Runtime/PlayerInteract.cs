using UnityEngine;
using Pixelogic.helper;
using UnityEngine.InputSystem;

namespace Pixelogic.Util
{
    [RequireComponent(typeof(InputActionManager))]
 
    public class PlayerInteract : MonoBehaviour
    {
        public Camera camera;
        InputActionManager actionManager;
        public float maxLookDist = 10;

        public Iinteractable interactedObject = null;
      
        private void Awake()
        {
            if (camera == null) camera = Camera.main;
         actionManager = GetComponent<InputActionManager>();
        
        }

        private void Update()
        {
            
         
            
        }
        public void lookForInteractable()
        {
            if (interactedObject != null)
            {
                interactedObject?.Interact();
                interactedObject = null;
                return;
            }
          
            if (interactedObject == null)
            {
                Physics.Raycast(camera.transform.position, camera.transform.forward * maxLookDist, out RaycastHit rayInfo);
                if (rayInfo.collider == null) return;
                interactedObject = rayInfo.collider.gameObject.GetComponent<Iinteractable>();
                interactedObject?.Interact();
            }
           

        
        }

     

        private void OnEnable()
        {
            actionManager.onInteract.AddListener(lookForInteractable);
        }
        private void OnDisable()
        {
            actionManager.onInteract.RemoveListener(lookForInteractable);
        }
    }
    
}