using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cinemachine
{
    /// <summary>
    /// This is a very simple behaviour that constrains its transform to a CinemachinePath.  
    /// It can be used to animate any objects along a path, or as a Follow target for 
    /// Cinemachine Virtual Cameras.
    /// </summary>
    [DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
    //[ExecuteAlways]
    [DisallowMultipleComponent]
    //[HelpURL(Documentation.BaseURL + "manual/CinemachineDollyCart.html")]
    public class ReviseCartCode : MonoBehaviour
    {
        /// <summary>The path to follow</summary>
        [Tooltip("The path to follow")]
        [HideInInspector] public CinemachinePathBase m_Path;
        public GameObject body;
        [HideInInspector] public float originalSpeed;
        [HideInInspector] public bool isStun = false;
        public bool isPushBack = false;
        private float pushBackSpeed = -10f;

        void Awake()
        {
            //m_Path = GameObject.FindWithTag("Track").GetComponent<CinemachinePathBase>();
            originalSpeed = m_Speed;
        }

        /// <summary>This enum defines the options available for the update method.</summary>
        public enum UpdateMethod
        {
            /// <summary>Updated in normal MonoBehaviour Update.</summary>
            Update,
            /// <summary>Updated in sync with the Physics module, in FixedUpdate</summary>
            FixedUpdate,
            /// <summary>Updated in normal MonoBehaviour LateUpdate</summary>
            LateUpdate
        };

        /// <summary>When to move the cart, if Velocity is non-zero</summary>
        [Tooltip("When to move the cart, if Velocity is non-zero")]
        public UpdateMethod m_UpdateMethod = UpdateMethod.Update;

        /// <summary>How to interpret the Path Position</summary>
        [Tooltip("How to interpret the Path Position.  If set to Path Units, values are as follows: 0 represents the first waypoint on the path, 1 is the second, and so on.  Values in-between are points on the path in between the waypoints.  If set to Distance, then Path Position represents distance along the path.")]
        public CinemachinePathBase.PositionUnits m_PositionUnits = CinemachinePathBase.PositionUnits.Distance;

        /// <summary>Move the cart with this speed</summary>
        [Tooltip("Move the cart with this speed along the path.  The value is interpreted according to the Position Units setting.")]
        [FormerlySerializedAs("m_Velocity")]
        public float m_Speed;

        /// <summary>The cart's current position on the path, in distance units</summary>
        [Tooltip("The position along the path at which the cart will be placed.  This can be animated directly or, if the velocity is non-zero, will be updated automatically.  The value is interpreted according to the Position Units setting.")]
        [FormerlySerializedAs("m_CurrentDistance")]
        public float m_Position;



        void Update()
        {
            float speed = Application.isPlaying ? m_Speed : 0;

            if (isPushBack) SetCartPosition(m_Position + pushBackSpeed * Time.deltaTime);
            if (isStun) return;
            
            if (m_UpdateMethod == UpdateMethod.Update)
                SetCartPosition(m_Position + speed * Time.deltaTime);
        }


        void SetCartPosition(float distanceAlongPath)
        {
            if (m_Path != null)
            {
                m_Position = m_Path.StandardizeUnit(distanceAlongPath, m_PositionUnits);
                
                Vector3 newPosition = m_Path.EvaluatePositionAtUnit(m_Position, m_PositionUnits);

                if (!isPushBack)
                {
                    if (transform.position.x > newPosition.x) body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    else if (transform.position.x < newPosition.x) body.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }

                transform.position = newPosition;
            }
        }

        public void SetPath(CinemachinePathBase myPath)
        {
            m_Path = myPath;
            m_Position = 0;
        }

        public void ResetCart()
        {
            m_Speed = originalSpeed;
            isStun = false;
            StopCoroutine("PushCoroutine");
        }

        public void PushBack()
        {
            StartCoroutine("PushCoroutine");
        }

        IEnumerator PushCoroutine()
        {
            isPushBack = true;
            yield return new WaitForSeconds(0.07f);
            isPushBack = false;
        }
    }
}