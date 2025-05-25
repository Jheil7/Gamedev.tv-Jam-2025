using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FormSwap : MonoBehaviour
{
    [SerializeField] List<GameObject> formList;
    [SerializeField] private PlayerAudio audioController;
    
    [SerializeField] CinemachineCamera zoomedInCam;
    [SerializeField] CinemachineCamera zoomedOutCam;

    private IInteract currentForm;
    private InteractF currentFormF;
    public bool bigFormUnlocked;

    [SerializeField] private FormBehaviorBase currentFormBehavior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool BigFormUnlocked
    {
        get { return bigFormUnlocked; }
        set { bigFormUnlocked = value; }  
    }

    void Start()
    {
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
        if (value.isPressed)
        {
            SetActiveForm(0);
            SwitchToZoomedIn();
        }


    }

    public void OnSecondaryFire(InputValue value)
    {
        //set active form to big form
        if (value.isPressed&&bigFormUnlocked)
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
