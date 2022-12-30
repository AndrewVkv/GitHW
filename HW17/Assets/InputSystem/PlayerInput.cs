// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""OnFoot"",
            ""id"": ""3403dbb6-8ab4-4c7c-b3ba-39518e7a9696"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""eb8daf23-d548-4be8-99fa-f7fa7bb218e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""79e061ce-1323-4c3a-8a65-6a88e4f0c042"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""04469aa6-28d0-4465-be25-0bee57a706bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""fe8d09a9-0608-4e39-a8f1-60e5efa01817"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d8a914a5-e587-4dcd-b2fc-f3c67d7b7215"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3455434f-acdb-4de2-972e-955e81662893"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ac05720-bbd2-4f5b-929d-e7be407e5fe6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ab013ae-284e-427e-a827-3515ec4e0020"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""241834ab-30e1-4f0a-b21a-7fecd4719e28"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3523b5b9-be8b-49f6-a7e1-e69ec9974f3e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""JumpRoll"",
            ""id"": ""9bfdf636-705f-4d85-93e4-a2ba7ce8d53a"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0e02add1-f3db-4de1-b5b7-1eb2e9d196ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""099dc59a-9293-46e7-8247-063a3ceb3b21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""450894be-b1cc-4360-bc9d-aeee1afcb25c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33d6dc51-8ac9-44d3-b2f9-f3ec2118970e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KB"",
            ""bindingGroup"": ""KB"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // OnFoot
        m_OnFoot = asset.FindActionMap("OnFoot", throwIfNotFound: true);
        m_OnFoot_MoveLeft = m_OnFoot.FindAction("MoveLeft", throwIfNotFound: true);
        m_OnFoot_MoveRight = m_OnFoot.FindAction("MoveRight", throwIfNotFound: true);
        m_OnFoot_Jump = m_OnFoot.FindAction("Jump", throwIfNotFound: true);
        m_OnFoot_Roll = m_OnFoot.FindAction("Roll", throwIfNotFound: true);
        m_OnFoot_Shoot = m_OnFoot.FindAction("Shoot", throwIfNotFound: true);
        // JumpRoll
        m_JumpRoll = asset.FindActionMap("JumpRoll", throwIfNotFound: true);
        m_JumpRoll_Jump = m_JumpRoll.FindAction("Jump", throwIfNotFound: true);
        m_JumpRoll_Roll = m_JumpRoll.FindAction("Roll", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // OnFoot
    private readonly InputActionMap m_OnFoot;
    private IOnFootActions m_OnFootActionsCallbackInterface;
    private readonly InputAction m_OnFoot_MoveLeft;
    private readonly InputAction m_OnFoot_MoveRight;
    private readonly InputAction m_OnFoot_Jump;
    private readonly InputAction m_OnFoot_Roll;
    private readonly InputAction m_OnFoot_Shoot;
    public struct OnFootActions
    {
        private @PlayerInput m_Wrapper;
        public OnFootActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_OnFoot_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_OnFoot_MoveRight;
        public InputAction @Jump => m_Wrapper.m_OnFoot_Jump;
        public InputAction @Roll => m_Wrapper.m_OnFoot_Roll;
        public InputAction @Shoot => m_Wrapper.m_OnFoot_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_OnFoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnFootActions set) { return set.Get(); }
        public void SetCallbacks(IOnFootActions instance)
        {
            if (m_Wrapper.m_OnFootActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnMoveRight;
                @Jump.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Roll.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRoll;
                @Shoot.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_OnFootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public OnFootActions @OnFoot => new OnFootActions(this);

    // JumpRoll
    private readonly InputActionMap m_JumpRoll;
    private IJumpRollActions m_JumpRollActionsCallbackInterface;
    private readonly InputAction m_JumpRoll_Jump;
    private readonly InputAction m_JumpRoll_Roll;
    public struct JumpRollActions
    {
        private @PlayerInput m_Wrapper;
        public JumpRollActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_JumpRoll_Jump;
        public InputAction @Roll => m_Wrapper.m_JumpRoll_Roll;
        public InputActionMap Get() { return m_Wrapper.m_JumpRoll; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JumpRollActions set) { return set.Get(); }
        public void SetCallbacks(IJumpRollActions instance)
        {
            if (m_Wrapper.m_JumpRollActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_JumpRollActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_JumpRollActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_JumpRollActionsCallbackInterface.OnJump;
                @Roll.started -= m_Wrapper.m_JumpRollActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_JumpRollActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_JumpRollActionsCallbackInterface.OnRoll;
            }
            m_Wrapper.m_JumpRollActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
            }
        }
    }
    public JumpRollActions @JumpRoll => new JumpRollActions(this);
    private int m_KBSchemeIndex = -1;
    public InputControlScheme KBScheme
    {
        get
        {
            if (m_KBSchemeIndex == -1) m_KBSchemeIndex = asset.FindControlSchemeIndex("KB");
            return asset.controlSchemes[m_KBSchemeIndex];
        }
    }
    public interface IOnFootActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IJumpRollActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
    }
}
