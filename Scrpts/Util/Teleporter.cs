using EyeIllusions.helper;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Pixelogic.Util
{
    public class Teleporter : MonoBehaviour, Iinteractable
    {
        public SceneAsset sceneToSwitchTo;
      
        public void Interact()
        {
            if (sceneToSwitchTo != null)
            {
                SceneManager.LoadScene(sceneToSwitchTo.name);
            }
            else
            {
                Debug.LogWarning("There is no scene on this object.");
            }
        }


    }
}