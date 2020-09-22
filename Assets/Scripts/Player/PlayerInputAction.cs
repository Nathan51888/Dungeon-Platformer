// GENERATED AUTOMATICALLY FROM 'Assets/Unity/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

public class PlayerInputAction : IInputActionCollection, IDisposable
{
    // Debug
    private readonly InputActionMap m_Debug;
    private readonly InputAction m_Debug_ReloadScene;

    // InAir
    private readonly InputActionMap m_InAir;
    private readonly InputAction m_InAir_Dash;
    private readonly InputAction m_InAir_Move;

    // OnGround
    private readonly InputActionMap m_OnGround;
    private readonly InputAction m_OnGround_Dash;
    private readonly InputAction m_OnGround_Jump;
    private readonly InputAction m_OnGround_Move;
    private IDebugActions m_DebugActionsCallbackInterface;
    private IInAirActions m_InAirActionsCallbackInterface;
    private int m_KeyboardSchemeIndex = -1;
    private IOnGroundActions m_OnGroundActionsCallbackInterface;

    public PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""OnGround"",
            ""id"": ""7cca59f8-e0ff-48fe-93ac-6becd18a6018"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bbac8ebf-e1d1-475f-b51b-fce4daba9b44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""05e230ab-56c8-44a0-bb15-e15d1cce51f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e093a892-b775-4eb9-9064-1c80a43d5024"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98a49a8a-08ee-4500-a068-2742ea421e83"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b718be5a-5f62-4dd7-9e8c-2ca016a31465"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c329ebf6-c4e9-4cfc-b00c-7c9dfbf0266a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c30bb4f8-9160-4cc9-a152-c3a6795dd6bd"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6e30349-cbe3-424a-805a-f576a80f64df"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""df12870d-2ab5-4ab9-b55d-14d25221b813"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ec8fe8f8-e0b1-40d4-b80c-2bca4a5f7f66"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""87574d26-50a9-4962-9bd8-ba79215ba852"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""17376505-64a0-4fdb-b82e-b1ef1075d6d7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""63bb60e1-2d2b-4251-981d-06b312b9d0cf"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bc73be83-dab6-4428-a54e-3674da0a265b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""InAir"",
            ""id"": ""f5990b12-812f-423e-befb-a5bd5c1ab943"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ae80a1cd-d87a-4186-a01b-00ae247d3337"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""44918467-d092-4211-bd87-b306d26682ec"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fa73ae5f-bab2-4efb-907e-2606c0dd4d46"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""676a64d3-d452-46a6-8fa2-daf847a124e3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e5489352-2529-4334-ae98-7fc6b5c4d6ad"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1668113c-2261-444f-9a58-09a88484de84"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""00e7cd41-7089-4b8c-91f1-ce2475f997b7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""76226e84-e3cc-4f69-848b-d733fc233918"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0ff775ba-e260-4e0b-89c2-e25d9f65810f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""a9ee72fc-3511-4070-bd1c-fe192b2009c7"",
            ""actions"": [
                {
                    ""name"": ""Reload Scene"",
                    ""type"": ""Button"",
                    ""id"": ""c4d0f874-4765-4c9a-a7c7-f6e98b50e312"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1840b71-9502-4994-948c-dca045bc8ec4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reload Scene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
        // OnGround
        m_OnGround = asset.FindActionMap("OnGround", true);
        m_OnGround_Jump = m_OnGround.FindAction("Jump", true);
        m_OnGround_Dash = m_OnGround.FindAction("Dash", true);
        m_OnGround_Move = m_OnGround.FindAction("Move", true);
        // InAir
        m_InAir = asset.FindActionMap("InAir", true);
        m_InAir_Dash = m_InAir.FindAction("Dash", true);
        m_InAir_Move = m_InAir.FindAction("Move", true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", true);
        m_Debug_ReloadScene = m_Debug.FindAction("Reload Scene", true);
    }

    public InputActionAsset asset { get; }

    public OnGroundActions OnGround => new OnGroundActions(this);

    public InAirActions InAir => new InAirActions(this);

    public DebugActions Debug => new DebugActions(this);

    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }

    public void Dispose()
    {
        Object.Destroy(asset);
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

    public struct OnGroundActions
    {
        private readonly PlayerInputAction m_Wrapper;

        public OnGroundActions(PlayerInputAction wrapper)
        {
            m_Wrapper = wrapper;
        }

        public InputAction Jump => m_Wrapper.m_OnGround_Jump;
        public InputAction Dash => m_Wrapper.m_OnGround_Dash;
        public InputAction Move => m_Wrapper.m_OnGround_Move;

        public InputActionMap Get()
        {
            return m_Wrapper.m_OnGround;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(OnGroundActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IOnGroundActions instance)
        {
            if (m_Wrapper.m_OnGroundActionsCallbackInterface != null)
            {
                Jump.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                Dash.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnDash;
                Dash.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnDash;
                Dash.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnDash;
                Move.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnMove;
            }

            m_Wrapper.m_OnGroundActionsCallbackInterface = instance;
            if (instance != null)
            {
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Dash.started += instance.OnDash;
                Dash.performed += instance.OnDash;
                Dash.canceled += instance.OnDash;
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
            }
        }
    }

    public struct InAirActions
    {
        private readonly PlayerInputAction m_Wrapper;

        public InAirActions(PlayerInputAction wrapper)
        {
            m_Wrapper = wrapper;
        }

        public InputAction Dash => m_Wrapper.m_InAir_Dash;
        public InputAction Move => m_Wrapper.m_InAir_Move;

        public InputActionMap Get()
        {
            return m_Wrapper.m_InAir;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(InAirActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IInAirActions instance)
        {
            if (m_Wrapper.m_InAirActionsCallbackInterface != null)
            {
                Dash.started -= m_Wrapper.m_InAirActionsCallbackInterface.OnDash;
                Dash.performed -= m_Wrapper.m_InAirActionsCallbackInterface.OnDash;
                Dash.canceled -= m_Wrapper.m_InAirActionsCallbackInterface.OnDash;
                Move.started -= m_Wrapper.m_InAirActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_InAirActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_InAirActionsCallbackInterface.OnMove;
            }

            m_Wrapper.m_InAirActionsCallbackInterface = instance;
            if (instance != null)
            {
                Dash.started += instance.OnDash;
                Dash.performed += instance.OnDash;
                Dash.canceled += instance.OnDash;
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
            }
        }
    }

    public struct DebugActions
    {
        private readonly PlayerInputAction m_Wrapper;

        public DebugActions(PlayerInputAction wrapper)
        {
            m_Wrapper = wrapper;
        }

        public InputAction ReloadScene => m_Wrapper.m_Debug_ReloadScene;

        public InputActionMap Get()
        {
            return m_Wrapper.m_Debug;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(DebugActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                ReloadScene.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnReloadScene;
                ReloadScene.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnReloadScene;
                ReloadScene.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnReloadScene;
            }

            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                ReloadScene.started += instance.OnReloadScene;
                ReloadScene.performed += instance.OnReloadScene;
                ReloadScene.canceled += instance.OnReloadScene;
            }
        }
    }

    public interface IOnGroundActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }

    public interface IInAirActions
    {
        void OnDash(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }

    public interface IDebugActions
    {
        void OnReloadScene(InputAction.CallbackContext context);
    }
}