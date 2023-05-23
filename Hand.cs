using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Hand : MonoBehaviour
{
    public float speed;
    Animator animator;

    public GameObject Knuckles;
    public GameObject Pointer;

    private float gripTarget;
    private float gripCurrent;
    private string animatorGripParam = "Grip";

    private float triggerTarget;
    private float triggerCurrent;
    private string animatorTriggerParam = "Trigger";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        // Disable the initial state of Knuckles and Pointers, otherwise they will both appear until a button is pushed.
        Knuckles.SetActive(false);
        Pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
        CheckGripAndTrigger();        
    }

    internal void SetGrip(float value)
    {
        gripTarget = value;
    }

    internal void SetTrigger(float value)
    {
        triggerTarget = value;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }

    }

    void CheckGripAndTrigger()
    {
        if (gripCurrent != gripTarget || triggerCurrent != triggerTarget)
        {
            if (gripTarget > 0.01f && triggerTarget > 0.01f)
            {
                Knuckles.SetActive(true);
                Pointer.SetActive(false);
            }
            else if (gripTarget > 0.01f && triggerTarget < 0.01f)
            {
                Knuckles.SetActive(false);
                Pointer.SetActive(true);
            }
            else
            {
                Knuckles.SetActive(false);
                Pointer.SetActive(false);
            }
        }
    }
}
