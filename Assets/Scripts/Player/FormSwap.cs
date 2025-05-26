using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FormSwap : MonoBehaviour
{
    [SerializeField] List<GameObject> formList;
    [SerializeField] private PlayerAudio audioController;

    [SerializeField] private Animator smallFormAnimator;
    [SerializeField] private Animator bigFormAnimator;
    private Animator currentAnimator;
    public Animator CurrentAnimator => currentAnimator;
    
    [SerializeField] CinemachineCamera zoomedInCam;
    [SerializeField] CinemachineCamera zoomedOutCam;

    private IInteract currentForm;
    private InteractF currentFormF;
    public bool bigFormUnlocked;

    [SerializeField] private FormBehaviorBase currentFormBehavior;

    public bool movementEnabledForPause;
    private bool small = true;


    public bool BigFormUnlocked
    {
        get { return bigFormUnlocked; }
        set { bigFormUnlocked = value; }
    }

    public bool MovementEnabledForPause
    {
        get { return movementEnabledForPause; }
        set { movementEnabledForPause = value; }
    }

    void Start()
    {
        movementEnabledForPause = true;
        bigFormUnlocked = false;
        SetActiveForm(0);
        SwitchToZoomedIn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFire(InputValue value)
    {
        //set active form to small form
        if (value.isPressed&&movementEnabledForPause)
        {
            SetActiveForm(0);
            SwitchToZoomedIn();
        }


    }

    public void OnSecondaryFire(InputValue value)
    {
        //set active form to big form
        if (value.isPressed&&bigFormUnlocked&&movementEnabledForPause)
        {
            SetActiveForm(1);
            SwitchToZoomedOut();
        }
    }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            currentForm?.InteractWithObject();
        }
    }

    public void OnInteractF(InputValue value)
    {
        if (value.isPressed)
        {
            currentFormBehavior?.InteractWithObjectF();
        }
    }

    public void SetActiveForm(int index)
    {
        // Drop any held object before swapping forms
        foreach (GameObject form in formList)
        {
            if (form.activeSelf)
            {
                var dropper = form.GetComponent<FormBehaviorBase>();
                dropper?.ForceDropIfCarrying();

                audioController.SetForm(index == 0
                ? PlayerAudio.PlayerForm.Small
                : PlayerAudio.PlayerForm.Big);
            }
        }

        // Activate the selected form
        for (int i = 0; i < formList.Count; i++)
        {
            formList[i].SetActive(i == index);
        }
        GameObject activeForm = formList[index];
        currentForm = activeForm.GetComponent<IInteract>();
        currentFormF = activeForm.GetComponent<InteractF>();
        currentFormBehavior = activeForm.GetComponent<FormBehaviorBase>();
        
        currentAnimator = index == 0 ? smallFormAnimator : bigFormAnimator;
        if (bigFormUnlocked)
        {
            if (index == 0 && !small)
            {
                currentAnimator.Play("shrink");
                small = !small;
            }
            else if(index == 1 && small){ 
                currentAnimator.Play("grow");
                small = !small;
            }
            else
            {
                 // do nothing
            }
        }
    }


    public void SwitchToZoomedIn()
    {
        zoomedInCam.Priority = 10;
        zoomedOutCam.Priority = 0;
    }

    public void SwitchToZoomedOut()
    {
        zoomedInCam.Priority = 0;
        zoomedOutCam.Priority = 10;
    }

}
