// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInput.inputactions'

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
            ""id"": ""da4e6d3b-b3a5-46fe-851b-ae8ad766d27e"",
            ""actions"": [
                {
                    ""name"": ""LeftMove"",
                    ""type"": ""Button"",
                    ""id"": ""adcca868-5b31-444e-bd14-3af5d950dbe4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMove"",
                    ""type"": ""Button"",
                    ""id"": ""88a8f66c-ed8c-4287-a667-37031f751bbf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d094acad-ce52-4dcf-85d9-7e3b0eff87c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""53bee33d-d48b-42e8-b559-d0d407ecbab0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""9131f080-c5dd-488f-8491-7d64ca20c9e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""f8195ee8-12e0-4be4-a0fb-a5debe7fdb10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""059fa407-bd93-425e-81f1-158e916c53a8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""K&M"",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc6907fe-1b58-4819-8bf6-d57c43eb6581"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89a864d0-0a23-4e2b-bbb9-ec300d212f9f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""K&M"",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac19c0ad-4cd9-40a7-a51f-9a14b0d3042e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""127a2478-9617-4140-bf0d-37eb9e7130e5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""K&M"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4bb73d5-20d2-4240-ac7d-8526cc9cc349"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b8fc389-7e9e-470a-8e30-38c80337f558"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""079c0ffa-0fe1-4650-a046-e19212c83fd1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""K&M"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9aa8cf1f-2137-4f20-a75b-c96ee517d73f"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88a15f0c-6f25-42af-ab92-87f6ba1116b1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3353de4-796c-4eff-bc2b-177272099bbe"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""K&M"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""246a6eb0-da58-4a4e-93ee-b78a4c079b9a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15b07f76-dd8b-41d1-9861-921cf1e01023"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""K&M"",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc98e087-b911-4d68-9e02-8abcf677017a"",
                    ""path"": ""<Gamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""K&M"",
            ""bindingGroup"": ""K&M"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<VirtualMouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": []
        }
    ]
}");
        // OnFoot
        m_OnFoot = asset.FindActionMap("OnFoot", throwIfNotFound: true);
        m_OnFoot_LeftMove = m_OnFoot.FindAction("LeftMove", throwIfNotFound: true);
        m_OnFoot_RightMove = m_OnFoot.FindAction("RightMove", throwIfNotFound: true);
        m_OnFoot_Jump = m_OnFoot.FindAction("Jump", throwIfNotFound: true);
        m_OnFoot_Roll = m_OnFoot.FindAction("Roll", throwIfNotFound: true);
        m_OnFoot_Fire = m_OnFoot.FindAction("Fire", throwIfNotFound: true);
        m_OnFoot_Esc = m_OnFoot.FindAction("Esc", throwIfNotFound: true);
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
    private readonly InputAction m_OnFoot_LeftMove;
    private readonly InputAction m_OnFoot_RightMove;
    private readonly InputAction m_OnFoot_Jump;
    private readonly InputAction m_OnFoot_Roll;
    private readonly InputAction m_OnFoot_Fire;
    private readonly InputAction m_OnFoot_Esc;
    public struct OnFootActions
    {
        private @PlayerInput m_Wrapper;
        public OnFootActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftMove => m_Wrapper.m_OnFoot_LeftMove;
        public InputAction @RightMove => m_Wrapper.m_OnFoot_RightMove;
        public InputAction @Jump => m_Wrapper.m_OnFoot_Jump;
        public InputAction @Roll => m_Wrapper.m_OnFoot_Roll;
        public InputAction @Fire => m_Wrapper.m_OnFoot_Fire;
        public InputAction @Esc => m_Wrapper.m_OnFoot_Esc;
        public InputActionMap Get() { return m_Wrapper.m_OnFoot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnFootActions set) { return set.Get(); }
        public void SetCallbacks(IOnFootActions instance)
        {
            if (m_Wrapper.m_OnFootActionsCallbackInterface != null)
            {
                @LeftMove.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnLeftMove;
                @LeftMove.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnLeftMove;
                @LeftMove.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnLeftMove;
                @RightMove.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRightMove;
                @RightMove.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRightMove;
                @RightMove.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRightMove;
                @Jump.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnJump;
                @Roll.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnRoll;
                @Fire.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnFire;
                @Esc.started -= m_Wrapper.m_OnFootActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_OnFootActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_OnFootActionsCallbackInterface.OnEsc;
            }
            m_Wrapper.m_OnFootActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftMove.started += instance.OnLeftMove;
                @LeftMove.performed += instance.OnLeftMove;
                @LeftMove.canceled += instance.OnLeftMove;
                @RightMove.started += instance.OnRightMove;
                @RightMove.performed += instance.OnRightMove;
                @RightMove.canceled += instance.OnRightMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
            }
        }
    }
    public OnFootActions @OnFoot => new OnFootActions(this);
    private int m_KMSchemeIndex = -1;
    public InputControlScheme KMScheme
    {
        get
        {
            if (m_KMSchemeIndex == -1) m_KMSchemeIndex = asset.FindControlSchemeIndex("K&M");
            return asset.controlSchemes[m_KMSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IOnFootActions
    {
        void OnLeftMove(InputAction.CallbackContext context);
        void OnRightMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnEsc(InputAction.CallbackContext context);
    }
}
