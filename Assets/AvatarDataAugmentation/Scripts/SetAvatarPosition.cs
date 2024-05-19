
using UnityEngine;

public class SetAvatarPosition : MonoBehaviour
{
    private Animator anim;
    private Vector3 desiredHeadPosition = new Vector3(1000f, 300f, 0f); 

    void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 heightDifference = CalculateHeightDifference();
        MoveObjectByHeightDifference(heightDifference);
    }

    Vector3 CalculateHeightDifference()
    {
        Transform headTransform = anim.GetBoneTransform(HumanBodyBones.Head);

        if (headTransform == null)
        {
            Debug.LogError("Head bone not found in Animator component!");
            return Vector3.zero;
        }

        Vector3 currentHeadPosition = headTransform.position;
        return desiredHeadPosition - currentHeadPosition;
    }

    void MoveObjectByHeightDifference(Vector3 heightDifference)
    {
        transform.position += heightDifference;
    }
}
