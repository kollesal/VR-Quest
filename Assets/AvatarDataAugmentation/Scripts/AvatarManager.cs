using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public RuntimeAnimatorController drinkingNichtKompensiertController;
    public RuntimeAnimatorController drinkingKompensiertController01;

    void Start()
    {
        // Set rotation for avatars
        SetAvatarRotation();

        // Assign animator controller and ExportCSVKompensiert component to "kompensiert" tagged GameObjects
        AssignAnimatorController();
    }

    void SetAvatarRotation()
    {
        // Find all GameObjects tagged as "Kompensiert"
        GameObject[] avatars = GameObject.FindGameObjectsWithTag("Kompensiert");

        // Iterate through each avatar and set its rotation
        foreach (GameObject avatar in avatars)
        {
            // Get the current rotation of the avatar
            Quaternion currentRotation = avatar.transform.rotation;

            // Set the y and z rotation to 180 degrees
            currentRotation.eulerAngles = new Vector3(currentRotation.eulerAngles.x, 180, 180);

            // Apply the new rotation back to the avatar
            avatar.transform.rotation = currentRotation;
        }

        // Find all GameObjects tagged as "Kompensiert"
        GameObject[] avatarsN = GameObject.FindGameObjectsWithTag("Nicht Kompensiert");

        // Iterate through each avatar and set its rotation
        foreach (GameObject avatar in avatarsN)
        {
            // Get the current rotation of the avatar
            Quaternion currentRotation = avatar.transform.rotation;

            // Set the y and z rotation to 180 degrees
            currentRotation.eulerAngles = new Vector3(currentRotation.eulerAngles.x, 180, 180);

            // Apply the new rotation back to the avatar
            avatar.transform.rotation = currentRotation;
        }
    }

    void AssignAnimatorController()
    {
        // Find all GameObjects tagged as "Kompensiert"
        GameObject[] kompensiertObjects = GameObject.FindGameObjectsWithTag("Kompensiert");

        // Iterate through each object and assign the animator controller and ExportCSVKompensiert component
        foreach (GameObject obj in kompensiertObjects)
        {
            // Ensure the Animator component exists and assign the controller
            Animator animator = obj.GetComponent<Animator>();
            if (animator == null)
            {
                animator = obj.AddComponent<Animator>();
            }

            // Assign the specified animator controller
            animator.runtimeAnimatorController = drinkingKompensiertController01;

            // Add the ExportCSVKompensiert component if it doesn't exist
            ExportCSVKompensiert exportCSVComponent = obj.GetComponent<ExportCSVKompensiert>();
            if (exportCSVComponent == null)
            {
                obj.AddComponent<ExportCSVKompensiert>();
            }
        }

        // Find all GameObjects tagged as "Nicht Kompensiert"
        GameObject[] nichtKompensiertObjects = GameObject.FindGameObjectsWithTag("Nicht Kompensiert");

        // Iterate through each object and assign the ExportCSVNichtKompensiert script
        foreach (GameObject obj in nichtKompensiertObjects)
        {
            // Ensure the Animator component exists and assign the controller
            Animator animatorN = obj.GetComponent<Animator>();
            if (animatorN == null)
            {
                animatorN = obj.AddComponent<Animator>();
            }

            // Assign the specified animator controller
            animatorN.runtimeAnimatorController = drinkingNichtKompensiertController;
            // Add the ExportCSVNichtKompensiert script if it doesn't exist
            ExportCSVNichtKompensiert exportCSVComponent = obj.GetComponent<ExportCSVNichtKompensiert>();
            if (exportCSVComponent == null)
            {
                obj.AddComponent<ExportCSVNichtKompensiert>();
            }


        }
    }
}
