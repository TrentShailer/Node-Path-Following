using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    private void OnDrawGizmos()
    {
		Gizmos.color = new Color(0, 1, 0, 0.5f);

		Gizmos.DrawCube(transform.position, new Vector3(0.2f, 0.2f));
	}
}
