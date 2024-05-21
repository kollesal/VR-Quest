using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.IO;

public class AvatarManager : MonoBehaviour
{
    private RuntimeAnimatorController drinkingNichtKompensiertController;
    private RuntimeAnimatorController drinkingKompensiertController01;
    private Avatar avatar;

    void Start()
    {
        LoadAnimatorControllersAndAvatar();
        SetAvatarRotation();
        AssignAnimatorController();
        ChangeAnimationsToHumanoid();
    }

    void LoadAnimatorControllersAndAvatar()
    {
        string drinkingNichtKompensiertControllerPath = "Assets/AvatarDataAugmentation/01 Collecting Data: DeepMotion Animations/nichtKompensiert/drinkingNichtKompensiertController.controller";
        string drinkingKompensiertController01Path = "Assets/AvatarDataAugmentation/01 Collecting Data: DeepMotion Animations/kompensiert/drinkingKompensiertController01.controller";
        string avatarPath = "Assets/AvatarDataAugmentation/01 Collecting Data: DeepMotion Animations/x.fbx"; // Replace with actual path

        drinkingNichtKompensiertController = AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(drinkingNichtKompensiertControllerPath);
        drinkingKompensiertController01 = AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(drinkingKompensiertController01Path);
        avatar = AssetDatabase.LoadAssetAtPath<Avatar>(avatarPath);
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
            animator.avatar = avatar;
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
            animatorN.avatar = avatar;
            ExportCSVNichtKompensiert exportCSVComponent = obj.GetComponent<ExportCSVNichtKompensiert>();
            if (exportCSVComponent == null)
            {
                obj.AddComponent<ExportCSVNichtKompensiert>();
            }
        }
    }

    void ChangeAnimationsToHumanoid()
    {
        string[] guids = AssetDatabase.FindAssets("t:AnimationClip");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ModelImporter modelImporter = AssetImporter.GetAtPath(path) as ModelImporter;

            if (modelImporter != null)
            {
                modelImporter.animationType = ModelImporterAnimationType.Human;
                modelImporter.avatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;

                string folderName = Path.GetDirectoryName(path);
                RuntimeAnimatorController targetController = null;

                if (folderName.Contains("kompensiert"))
                {
                    targetController = drinkingKompensiertController01;
                }
                else if (folderName.Contains("nichtKompensiert"))
                {
                    targetController = drinkingNichtKompensiertController;
                }

                AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(path);
                if (clip != null && targetController != null)
                {
                    AnimatorController animatorController = AssetDatabase.LoadAssetAtPath<AnimatorController>(AssetDatabase.GetAssetPath(targetController));
                    if (animatorController != null)
                    {
                        AnimatorControllerLayer[] layers = animatorController.layers;
                        if (layers.Length > 0)
                        {
                            AnimatorStateMachine stateMachine = layers[0].stateMachine;
                            if (stateMachine != null)
                            {
                                AnimatorState newState = stateMachine.AddState(clip.name);
                                newState.motion = clip;

                                AnimatorState previousState = null;
                                foreach (var state in stateMachine.states)
                                {
                                    if (previousState != null)
                                    {
                                        AnimatorStateTransition transition = previousState.AddTransition(newState);
                                        transition.hasExitTime = true;
                                        transition.exitTime = 1.0f;
                                    }
                                    previousState = state.state;
                                }

                                if (previousState != null)
                                {
                                    AnimatorStateTransition transition = previousState.AddTransition(newState);
                                    transition.hasExitTime = true;
                                    transition.exitTime = 1.0f;
                                }
                            }
                        }
                    }
                }

                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
                Debug.Log("Changed " + path + " to Humanoid, assigned avatar, and added to appropriate Animator Controller.");
            }
        }

        AssetDatabase.Refresh();
    }
}
