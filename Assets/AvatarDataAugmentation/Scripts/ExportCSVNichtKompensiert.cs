using UnityEngine;
using System.IO;
using System.Collections;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ExportCSVNichtKompensiert : MonoBehaviour
{
    Animator anim;
    string filename = "";
    string path = "";
    string compensation = "";
    int frameCount = 1; // Variable to keep track of the frame count
    private bool isNewAnimation = false; // Flag to indicate if a new animation has started
    private float lastAnimationTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CreateTextAsset();
        StartCoroutine(StartRecordingAfterDelay(0.1f));
    }

    private void CreateTextAsset()
    {
        filename = Application.dataPath + "/AvatarDataAugmentation/Data/KeypointsExportNichtKompensiert.csv";
        WriteColumnTitles();
    }

    private void WriteColumnTitles()
    {
        using (TextWriter tw = new StreamWriter(filename, false))
        {
            tw.WriteLine("path,frame,compensation,x_0,y_0,z_0,x_1,y_1,z_1,x_2,y_2,z_2,x_3,y_3,z_3,x_4,y_4,z_4,x_5,y_5,z_5,x_6,y_6,z_6,x_7,y_7,z_7,x_8,y_8,z_8,x_9,y_9,z_9,x_10,y_10,z_10,x_11,y_11,z_11,x_12,y_12,z_12,x_13,y_13,z_13,x_14,y_14,z_14,x_15,y_15,z_15,x_16,y_16,z_16,x_17,y_17,z_17,x_18,y_18,z_18,x_19,y_19,z_19,x_20,y_20,z_20,x_21,y_21,z_21,x_22,y_22,z_22,x_23,y_23,z_23,x_24,y_24,z_24,x_25,y_25,z_25,x_26,y_26,z_26,x_27,y_27,z_27,x_28,y_28,z_28,x_29,y_29,z_29,x_30,y_30,z_30,x_31,y_31,z_31,x_32,y_32,z_32");
        }
    }

    // Delay so that the Avatar Positioning isn't recorded
    IEnumerator StartRecordingAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Start recording
        StartCoroutine(RecordMovement());
    }

    IEnumerator RecordMovement()
    {
        while (true)
        {

            PushLine();

            // Original Video is 4S and has 152 Frames.
            // Duration per frame = Total duration / Number of frames
            // 4 seconds / 152 frames = 0.026 seconds per frame
            // Fitting number of Frames.
            yield return new WaitForSeconds(0.026f);

        }
    }

    private void PushLine()
    {
        // Get the current path
        path = filename;

        // Get the current time
        string currentTime = Time.time.ToString();

        // Get compensation
        compensation = "False";


        // Get the transform of the head bone
        Transform headTransform = anim.GetBoneTransform(HumanBodyBones.Head);
        // Extract the position of the head
         Vector3 headPosition = headTransform.position;

        // Get the position of the head directly from the Animator
        // Vector3 headPosition = transform.position;

        // Get the transform of the R shoulder bone
        Transform rShoulderTransform = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
        Vector3 rShoulderPosition = rShoulderTransform.position;

        Transform lShoulderTransform = anim.GetBoneTransform(HumanBodyBones.LeftShoulder);
        Vector3 lShoulderPosition = lShoulderTransform.position;

        Transform rElbowTransform = anim.GetBoneTransform(HumanBodyBones.RightLowerArm);
        Vector3 rElbowPosition = rElbowTransform.position;

        Transform lElbowTransform = anim.GetBoneTransform(HumanBodyBones.LeftLowerArm);
        Vector3 lElbowPosition = lElbowTransform.position;

        Transform rWristTransform = anim.GetBoneTransform(HumanBodyBones.RightHand);
        Vector3 rWristPosition = rWristTransform.position;

        Transform lWristTransform = anim.GetBoneTransform(HumanBodyBones.LeftHand);
        Vector3 lWristPosition = lWristTransform.position;

        Transform lPinkyTransform = anim.GetBoneTransform(HumanBodyBones.LeftLittleProximal);
        Vector3 lPinkyPosition = lPinkyTransform.position;

        Transform rPinkyTransform = anim.GetBoneTransform(HumanBodyBones.RightLittleProximal);
        Vector3 rPinkyPosition = rPinkyTransform.position;

        Transform lIndexTransform = anim.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
        Vector3 lIndexPosition = lIndexTransform.position;

        Transform rIndexTransform = anim.GetBoneTransform(HumanBodyBones.RightIndexProximal);
        Vector3 rIndexPosition = rIndexTransform.position;

        Transform lThumbTransform = anim.GetBoneTransform(HumanBodyBones.LeftThumbProximal);
        Vector3 lThumbPosition = lThumbTransform.position;

        Transform rThumbTransform = anim.GetBoneTransform(HumanBodyBones.RightThumbProximal);
        Vector3 rThumbPosition = rThumbTransform.position;

        Transform lHipTransform = anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        Vector3 lHipPosition = lHipTransform.position;

        Transform rHipTransform = anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
        Vector3 rHipPosition = rHipTransform.position;

        Transform lKneeTransform = anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        Vector3 lKneePosition = lKneeTransform.position;

        Transform rKneeTransform = anim.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        Vector3 rKneePosition = rKneeTransform.position;

        Transform lAnkleTransform = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        Vector3 lAnklePosition = lAnkleTransform.position;

        Transform rAnkleTransform = anim.GetBoneTransform(HumanBodyBones.RightFoot);
        Vector3 rAnklePosition = rAnkleTransform.position;

        Transform lFootIndexTransform = anim.GetBoneTransform(HumanBodyBones.LeftToes);
        Vector3 lFootIndexPosition = lFootIndexTransform.position;

        Transform rFootIndexTransform = anim.GetBoneTransform(HumanBodyBones.RightToes);
        Vector3 rFootIndexPosition = rFootIndexTransform.position;


        // Extract x, y, and z components separately
        string Headx = headPosition.x.ToString();
        string Heady = headPosition.y.ToString();
        string Headz = headPosition.z.ToString();

        string x1 = "0";
        string y1 = "0";
        string z1 = "0";

        string x2 = "0";
        string y2 = "0";
        string z2 = "0";

        string x3 = "0";
        string y3 = "0";
        string z3 = "0";

        string x4 = "0";
        string y4 = "0";
        string z4 = "0";

        string x5 = "0";
        string y5 = "0";
        string z5 = "0";

        string x6 = "0";
        string y6 = "0";
        string z6 = "0";

        string x7 = "0";
        string y7 = "0";
        string z7 = "0";

        string x8 = "0";
        string y8 = "0";
        string z8 = "0";

        string x9 = "0";
        string y9 = "0";
        string z9 = "0";

        string x10 = "0";
        string y10 = "0";
        string z10 = "0";

        string lShoulderX = lShoulderPosition.x.ToString();
        string lShoulderY = lShoulderPosition.y.ToString();
        string lShoulderZ = lShoulderPosition.z.ToString();

        string rShoulderX = rShoulderPosition.x.ToString();
        string rShoulderY = rShoulderPosition.y.ToString();
        string rShoulderZ = rShoulderPosition.z.ToString();

        string lElbowX = lElbowPosition.x.ToString();
        string lElbowY = lElbowPosition.y.ToString();
        string lElbowZ = lElbowPosition.z.ToString();        

        string rElbowX = rElbowPosition.x.ToString();
        string rElbowY = rElbowPosition.y.ToString();
        string rElbowZ = rElbowPosition.z.ToString();

        string lWristX = lWristPosition.x.ToString();
        string lWristY = lWristPosition.y.ToString();
        string lWristZ = lWristPosition.z.ToString();

        string rWristX = rWristPosition.x.ToString();
        string rWristY = rWristPosition.y.ToString();
        string rWristZ = rWristPosition.z.ToString();

        string lPinkyX = lPinkyPosition.x.ToString();
        string lPinkyY = lPinkyPosition.y.ToString();
        string lPinkyZ = lPinkyPosition.z.ToString();

        string rPinkyX = rPinkyPosition.x.ToString();
        string rPinkyY = rPinkyPosition.y.ToString();
        string rPinkyZ = rPinkyPosition.z.ToString();

        string lIndexX = lIndexPosition.x.ToString();
        string lIndexY = lIndexPosition.y.ToString();
        string lIndexZ = lIndexPosition.z.ToString();

        string rIndexX = rIndexPosition.x.ToString();
        string rIndexY = rIndexPosition.y.ToString();
        string rIndexZ = rIndexPosition.z.ToString();

        string lThumbX = lThumbPosition.x.ToString();
        string lThumbY = lThumbPosition.y.ToString();
        string lThumbZ = lThumbPosition.z.ToString();

        string rThumbX = rThumbPosition.x.ToString();
        string rThumbY = rThumbPosition.y.ToString();
        string rThumbZ = rThumbPosition.z.ToString();

        string lHipX = lHipPosition.x.ToString();
        string lHipY = lHipPosition.y.ToString();
        string lHipZ = lHipPosition.z.ToString();

        string rHipX = rHipPosition.x.ToString();
        string rHipY = rHipPosition.y.ToString();
        string rHipZ = rHipPosition.z.ToString();

        string lKneeX = lKneePosition.x.ToString();
        string lKneeY = lKneePosition.y.ToString();
        string lKneeZ = lKneePosition.z.ToString();

        string rKneeX = rKneePosition.x.ToString();
        string rKneeY = rKneePosition.y.ToString();
        string rKneeZ = rKneePosition.z.ToString();

        string lAnkleX = lAnklePosition.x.ToString();
        string lAnkleY = lAnklePosition.y.ToString();
        string lAnkleZ = lAnklePosition.z.ToString();

        string rAnkleX = rAnklePosition.x.ToString();
        string rAnkleY = rAnklePosition.y.ToString();
        string rAnkleZ = rAnklePosition.z.ToString();

        string x29 = "0";
        string y29 = "0";
        string z29 = "0";

        string x30 = "0";
        string y30 = "0";
        string z30 = "0";

        string lFootIndexX = lFootIndexPosition.x.ToString();
        string lFootIndexY = lFootIndexPosition.y.ToString();
        string lFootIndexZ = lFootIndexPosition.z.ToString();

        string rFootIndexX = rFootIndexPosition.x.ToString();
        string rFootIndexY = rFootIndexPosition.y.ToString();
        string rFootIndexZ = rFootIndexPosition.z.ToString();

        // Write the data to the CSV file
        using (TextWriter tw = new StreamWriter(filename, true))
        {
            tw.WriteLine(path + "," + frameCount + "," + compensation + "," +
                                             Headx + "," + Heady + "," +Headz + "," +
                                             x1 + "," + y1 + "," + z1 + "," +
                                             x2 + "," + y2 + "," + z2 + "," +
                                             x3 + "," + y3 + "," + z3 + "," +
                                             x4 + "," + y4 + "," + z4 + "," +
                                             x5 + "," + y5 + "," + z5 + "," +
                                             x6 + "," + y6 + "," + z6 + "," +
                                             x7 + "," + y7 + "," + z7 + "," +
                                             x8 + "," + y8 + "," + z8 + "," +
                                             x9 + "," + y9 + "," + z9 + "," +
                                             x10 + "," + y10 + "," + z10 + "," +
                                             lShoulderX + "," + lShoulderY + "," + lShoulderZ + "," +
                                             rShoulderX + "," + rShoulderY + "," + rShoulderZ + "," +
                                             lElbowX + "," + lElbowY + "," + lElbowZ + "," +
                                             rElbowX + "," + rElbowY + "," + rElbowZ + "," +
                                             lWristX + "," + lWristY + "," + lWristZ + "," +
                                             rWristX + "," + rWristY + "," + rWristZ + ","+
                                             lPinkyX + "," + lPinkyY + "," + lPinkyZ + "," +
                                             rPinkyX + "," + rPinkyY + "," + rPinkyZ + "," +
                                             lIndexX + "," + lIndexY + "," + lIndexZ + "," +
                                             rIndexX + "," + rIndexY + "," + rIndexZ + "," +
                                             lThumbX + "," + lThumbY + "," + lThumbZ + "," +
                                             rThumbX + "," + rThumbY + "," + rThumbZ + "," +
                                             lHipX + "," + lHipY + "," + lHipZ + "," +
                                             rHipX + "," + rHipY + "," + rHipZ + "," +
                                             lKneeX + "," + lKneeY + "," + lKneeZ + "," +
                                             rKneeX + "," + rKneeY + "," + rKneeZ + "," +
                                             lAnkleX + "," + lAnkleY + "," + lAnkleZ + "," +
                                             rAnkleX + "," + rAnkleY + "," + rAnkleZ + "," +
                                             x29 + "," + y29 + "," + z29 + "," +
                                             x30 + "," + y30 + "," + z30 + "," +
                                             lFootIndexX + "," + lFootIndexY + "," + lFootIndexZ + "," +
                                             rFootIndexX + "," + rFootIndexY + "," + rFootIndexZ);

        }
            frameCount++; // Increment frame count   
    }

    // Update is called once per frame
    void Update()
    {
        float currentAnimationTime = GetCurrentAnimationTime();

        if (currentAnimationTime < lastAnimationTime)
        {
            isNewAnimation = true;
            frameCount = 1;
        }
        else
        {
            isNewAnimation = false;
        }
        lastAnimationTime = currentAnimationTime;
        // Debug.Log("Animation Time (seconds): " + currentAnimationTime + "lastLoggedTime: " + lastAnimationTime + ", isNewAnimation: " + isNewAnimation);

    }

    private float GetCurrentAnimationTime()
    {
        return anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}


