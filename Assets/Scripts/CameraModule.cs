using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModule : MonoBehaviour
{
    public float distance = 10f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var player = FindObjectOfType<CharacterModule>();

            transform.position = new Vector3(
                player.transform.position.x,
                distance,
                player.transform.position.z -15f);
        }
    }
}
