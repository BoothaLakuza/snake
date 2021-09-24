using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleT : MonoBehaviour
{
    public _Muscle[] muscles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        foreach (_Muscle muscle in muscles)
        {
            muscle.ActivateMuscle();
        }

    }



    [System.Serializable]
    public class _Muscle
    {
        public Rigidbody2D bone;
        public float restRotaion;
        public float force;

        public void ActivateMuscle()
        {
            bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotaion, force * Time.fixedDeltaTime));
        }
    }
}
