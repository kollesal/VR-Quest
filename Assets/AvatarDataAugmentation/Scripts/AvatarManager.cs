using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public RuntimeAnimatorController drinkingNichtKompensiertController;
    public RuntimeAnimatorController drinkingKompensiertController01;


    void Start()
    {
#if UNITY_EDITOR
        ChangeAnimationsToHumanoid();
#endif

        SetAvatarRotation();
        AssignAnimatorController();
    }

    void SetAvatarRotation()
    {
        GameObject[] avatars = GameObject.FindGameObjectsWithTag("Kompensiert");
        foreach (GameObject avatar in avatars)
        {
            Quaternion currentRotation = avatar.transform.rotation;
            currentRotation.eulerAngles = new Vector3(currentRotation.eulerAngles.x, 180, 180);
            avatar.transform.rotation = currentRotation;
            avatar.transform.localScale = new Vector3(500, 500, 500);
        }

        GameObject[] avatarsN = GameObject.FindGameObjectsWithTag("Nicht Kompensiert");
        foreach (GameObject avatar in avatarsN)
        {
            Quaternion currentRotation = avatar.transform.rotation;
            currentRotation.eulerAngles = new Vector3(currentRotation.eulerAngles.x, 180, 180);
            avatar.transform.rotation = currentRotation;
            avatar.transform.localScale = new Vector3(500, 500, 500);
        }
    }

    void AssignAnimatorController()
    {
        GameObject[] kompensiertObjects = GameObject.FindGameObjectsWithTag("Kompensiert");
        foreach (GameObject obj in kompensiertObjects)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator == null)
            {
                animator = obj.AddComponent<Animator>();
            }

            animator.runtimeAnimatorController = drinkingKompensiertController01;
            ExportCSVKompensiert exportCSVComponent = obj.GetComponent<ExportCSVKompensiert>();
            if (exportCSVComponent == null)
            {
                obj.AddComponent<ExportCSVKompensiert>();
            }
        }

        GameObject[] nichtKompensiertObjects = GameObject.FindGameObjectsWithTag("Nicht Kompensiert");
        foreach (GameObject obj in nichtKompensiertObjects)
        {
            Animator animatorN = obj.GetComponent<Animator>();
            if (animatorN == null)
            {
                animatorN = obj.AddComponent<Animator>();
            }

            animatorN.runtimeAnimatorController = drinkingNichtKompensiertController;
            ExportCSVNichtKompensiert exportCSVComponent = obj.GetComponent<ExportCSVNichtKompensiert>();
            if (exportCSVComponent == null)
            {
                obj.AddComponent<ExportCSVNichtKompensiert>();
            }
        }
    }
    // New function to change animation type to Humanoid, assign an avatar, and add to the specified Animator Controller
    void ChangeAnimationsToHumanoid()
    {
        // Get all animation clips in the project
        string[] guids = AssetDatabase.FindAssets("t:AnimationClip");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ModelImporter modelImporter = AssetImporter.GetAtPath(path) as ModelImporter;


            // Set the animation type to Humanoid
            modelImporter.animationType = ModelImporterAnimationType.Human;

            // Set the avatar definition to "Create From This Model"
            modelImporter.avatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;

            // Apply the changes
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            Debug.Log("Changed " + path + " to Humanoid and set avatar definition to 'Create From This Model'.");
        }


        AssetDatabase.Refresh();
    }
}
