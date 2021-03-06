using System;
using UnityEngine;


    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private InputManager inputManager;        // reference to InputManager to use input
        AudioManager m_AudioManager;


        private void Start()
        {
            // gets the InputManager
            inputManager = InputManager.Instance;

            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
            m_AudioManager = FindObjectOfType<AudioManager>();
        }


        private void Update()
        {
            

            if (!m_Jump)
            {
                m_Jump = inputManager.GetPlayerJump();
            }

            

            Vector2 move = inputManager.GetPlayerMovement();

            if(move != new Vector2(0, 0) && FindObjectOfType<ThirdPersonCharacter>().m_IsGrounded)
            {
                m_AudioManager.Playe("Walk");
            }
            else
            {
                m_AudioManager.Pause("Walk");
            }
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
        {
            // read inputs
            Vector2 move = inputManager.GetPlayerMovement();
            bool crouch = inputManager.GetPlayerCrouch;

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                //calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = move.y * m_CamForward + move.x * m_Cam.right;
            }
            else
            {
                //we use world - relative directions in the case of no main camera
                m_Move = move.y * Vector3.forward + move.x * Vector3.right;
            }

            // walk speed multiplier
            if (inputManager.GetPlayerSneak) m_Move *= 0.5f;


            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }

