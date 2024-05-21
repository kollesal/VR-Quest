using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public RuntimeAnimatorController drinkingNichtKompensiertController;
    public RuntimeAnimatorController drinkingKompensiertController01;

    void Start()
    {
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
}
