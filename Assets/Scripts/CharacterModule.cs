using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModule : MonoBehaviour
{
    private Camera mainCamera;
    public float speed = 2.0f;
    private Rigidbody rigid;
    private Vector3 targetPosition = Vector3.zero;
    private Animator animator;

    private void Awake()
    {
        mainCamera = Camera.main;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                targetPosition = hit.point;
                animator.SetBool("isRun", true);
            }
        }

        if (Run())
            Trun(targetPosition);

    }

    private void Trun(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        Vector3 rXZ = new Vector3(dir.x, 0, dir.z);

        Quaternion rot = Quaternion.LookRotation(rXZ);
        rigid.rotation = Quaternion.RotateTowards(
            transform.rotation,
            rot,
            550.0f * Time.deltaTime);
    }

    private bool Run()
    {
        if (targetPosition.Equals(Vector3.zero)) return false;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime);

            return true;
        }

        targetPosition = Vector3.zero;
        animator.SetBool("isRun", false);
        return false;
    }
}
