using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FormSwap : MonoBehaviour
{
    [SerializeField] List<GameObject> formList;

    private IInteract currentForm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetActiveForm(0);
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
        }


    }

    public void OnSecondaryFire(InputValue value)
    {
        //set active form to big form
        if (value.isPressed)
        {
            SetActiveForm(1);
        }
    }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            currentForm?.InteractWithObject();
        }
    }

private void SetActiveForm(int index)
{
    // Drop any held object before swapping forms
    foreach (GameObject form in formList)
    {
        if (form.activeSelf)
        {
            var dropper = form.GetComponent<FormBehaviorBase>();
            dropper?.ForceDropIfCarrying();
        }
    }

    // Activate the selected form
    for (int i = 0; i < formList.Count; i++)
    {
        formList[i].SetActive(i == index);
    }

    currentForm = formList[index].GetComponent<IInteract>();
}

}
