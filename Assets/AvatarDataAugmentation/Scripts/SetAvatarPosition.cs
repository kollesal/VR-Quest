
using UnityEngine;

public class SetAvatarPosition : MonoBehaviour
{
    private Animator anim; // Reference to the Animator component
    private Vector3 desiredHeadPosition = new Vector3(1000f, 300f, 0f); // Desired head position

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to this GameObject
        anim = GetComponent<Animator>();

        // Calculate the height difference between the head and the desired position
        Vector3 heightDifference = CalculateHeightDifference();

        // Move the GameObject by the calculated height difference
        MoveObjectByHeightDifference(heightDifference);
    }

    Vector3 CalculateHeightDifference()
    {
        // Get the transform of the head bone from the Animator component
        Transform headTransform = anim.GetBoneTransform(HumanBodyBones.Head);

        if (headTransform == null)
        {
            Debug.LogError("Head bone not found in Animator component!");
            return Vector3.zero;
        }

        // Get the current head position
        Vector3 currentHeadPosition = headTransform.position;

        // Calculate the difference between the desired head position and the current head position
        return desiredHeadPosition - currentHeadPosition;
    }

    void MoveObjectByHeightDifference(Vector3 heightDifference)
    {
        // Move the entire GameObject by the calculated height difference
        transform.position += heightDifference;
    }
}
