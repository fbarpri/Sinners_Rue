using UnityEngine;

public class OvenDial : MonoBehaviour
{
    public Transform dial;

    private int dialIndex = 0;// start at 0
    private float stepAngle = 22.5f; // 360 / 16
    private float targetAngle;
    private float rotateSpeed = 300f; 
    private PlayerInventory inventory;
    public GameObject puzzlePanel;
    private DialogueManager dm;
    public string[] tempNotFound;
    public string[] tempFound;


    void Awake()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
        dm = FindFirstObjectByType<DialogueManager>();
    }

    void Start()
    {
        targetAngle = -dialIndex * stepAngle;
        dial.localRotation = Quaternion.Euler(0, 0, targetAngle);
        dm.StartDialogue(tempNotFound);
    }

 private bool closingAfterDialogue = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
            RotateDial(1);

        if (Input.GetKeyDown(KeyCode.W))
            puzzlePanel.SetActive(false);

        // smooth rotation??
        float currentAngle = dial.localEulerAngles.z;
        float newAngle = Mathf.MoveTowardsAngle(currentAngle, -targetAngle, rotateSpeed * Time.deltaTime);
        dial.localRotation = Quaternion.Euler(0, 0, newAngle);

        // needed to do this in update or else it wouldnt close
        if (closingAfterDialogue && !dm.IsActive())
        {
            puzzlePanel.SetActive(false);
            inventory.gotCorrectTemp = true;
            closingAfterDialogue = false;
        }
    }

    void RotateDial(int dir)
    {
        dialIndex += dir;

        if (dialIndex < 0) dialIndex = 15;
        if (dialIndex > 15) dialIndex = 0;

        targetAngle = dialIndex * stepAngle;

        if (dialIndex == 14)
        {
            dm.StartDialogue(tempFound);

            // Wait until dialogue finishes to close
            closingAfterDialogue = true;
        }
    }
}