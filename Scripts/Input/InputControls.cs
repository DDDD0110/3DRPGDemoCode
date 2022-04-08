// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ef854935-3d96-4750-9a95-2ea799fdd98f"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""06fe0a8a-34f8-496d-98b0-924cd3432e11"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""attack"",
                    ""type"": ""Button"",
                    ""id"": ""c22d7f67-c573-41a7-9f82-ef2fd87e6bd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""48dd9ec7-09f6-49f6-9c02-e4919aa89dfe"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2139d8c4-ba09-4369-8309-d478162d14cf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""260b8573-9b58-4fb7-b6d7-74046fb56e36"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5430d1e6-62b3-4b7e-b567-842775134526"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5e449624-d0c5-4e7b-92ed-b4350559319f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""436b0548-f27b-49cf-876a-ec3f9dadf143"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CAM"",
            ""id"": ""1294a4eb-71df-4427-b8c1-bdc8fee91edd"",
            ""actions"": [
                {
                    ""name"": ""camY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4f47245a-a2cc-47a3-8841-e0d2dc5c4074"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""cam"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ebc9427a-136d-4ae5-8932-b9fbc7456ec2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""38b5a867-d227-4570-a586-66055d8095f3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""cam"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6f4746df-9690-4359-bc8c-00dda359c65e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""cam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9bbac4d5-e5c4-49a8-89fc-0429705e68fe"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""cam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5ebfb2ad-8a28-4774-9fbb-550816ff0d9f"",
                    ""path"": ""1DAxis(minValue=0.5,whichSideWins=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""615f922d-5af0-45e2-8b79-7efee77c0e81"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""eecdbab1-1cb4-48ee-ae66-7f02c3d32a53"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player0"",
            ""id"": ""f2a20540-7e26-423f-bac5-032d6d56c8db"",
            ""actions"": [
                {
                    ""name"": ""attack"",
                    ""type"": ""Button"",
                    ""id"": ""7161c283-2636-43ba-b7bb-bf6dbc4643f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5172a207-74b1-4770-8922-5e234fc47f0e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_move = m_Player.FindAction("move", throwIfNotFound: true);
        m_Player_attack = m_Player.FindAction("attack", throwIfNotFound: true);
        // CAM
        m_CAM = asset.FindActionMap("CAM", throwIfNotFound: true);
        m_CAM_camY = m_CAM.FindAction("camY", throwIfNotFound: true);
        m_CAM_cam = m_CAM.FindAction("cam", throwIfNotFound: true);
        // Player0
        m_Player0 = asset.FindActionMap("Player0", throwIfNotFound: true);
        m_Player0_attack = m_Player0.FindAction("attack", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_move;
    private readonly InputAction m_Player_attack;
    public struct PlayerActions
    {
        private @InputControls m_Wrapper;
        public PlayerActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_Player_move;
        public InputAction @attack => m_Wrapper.m_Player_attack;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @attack.started += instance.OnAttack;
                @attack.performed += instance.OnAttack;
                @attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // CAM
    private readonly InputActionMap m_CAM;
    private ICAMActions m_CAMActionsCallbackInterface;
    private readonly InputAction m_CAM_camY;
    private readonly InputAction m_CAM_cam;
    public struct CAMActions
    {
        private @InputControls m_Wrapper;
        public CAMActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @camY => m_Wrapper.m_CAM_camY;
        public InputAction @cam => m_Wrapper.m_CAM_cam;
        public InputActionMap Get() { return m_Wrapper.m_CAM; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CAMActions set) { return set.Get(); }
        public void SetCallbacks(ICAMActions instance)
        {
            if (m_Wrapper.m_CAMActionsCallbackInterface != null)
            {
                @camY.started -= m_Wrapper.m_CAMActionsCallbackInterface.OnCamY;
                @camY.performed -= m_Wrapper.m_CAMActionsCallbackInterface.OnCamY;
                @camY.canceled -= m_Wrapper.m_CAMActionsCallbackInterface.OnCamY;
                @cam.started -= m_Wrapper.m_CAMActionsCallbackInterface.OnCam;
                @cam.performed -= m_Wrapper.m_CAMActionsCallbackInterface.OnCam;
                @cam.canceled -= m_Wrapper.m_CAMActionsCallbackInterface.OnCam;
            }
            m_Wrapper.m_CAMActionsCallbackInterface = instance;
            if (instance != null)
            {
                @camY.started += instance.OnCamY;
                @camY.performed += instance.OnCamY;
                @camY.canceled += instance.OnCamY;
                @cam.started += instance.OnCam;
                @cam.performed += instance.OnCam;
                @cam.canceled += instance.OnCam;
            }
        }
    }
    public CAMActions @CAM => new CAMActions(this);

    // Player0
    private readonly InputActionMap m_Player0;
    private IPlayer0Actions m_Player0ActionsCallbackInterface;
    private readonly InputAction m_Player0_attack;
    public struct Player0Actions
    {
        private @InputControls m_Wrapper;
        public Player0Actions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @attack => m_Wrapper.m_Player0_attack;
        public InputActionMap Get() { return m_Wrapper.m_Player0; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player0Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer0Actions instance)
        {
            if (m_Wrapper.m_Player0ActionsCallbackInterface != null)
            {
                @attack.started -= m_Wrapper.m_Player0ActionsCallbackInterface.OnAttack;
                @attack.performed -= m_Wrapper.m_Player0ActionsCallbackInterface.OnAttack;
                @attack.canceled -= m_Wrapper.m_Player0ActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_Player0ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @attack.started += instance.OnAttack;
                @attack.performed += instance.OnAttack;
                @attack.canceled += instance.OnAttack;
            }
        }
    }
    public Player0Actions @Player0 => new Player0Actions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface ICAMActions
    {
        void OnCamY(InputAction.CallbackContext context);
        void OnCam(InputAction.CallbackContext context);
    }
    public interface IPlayer0Actions
    {
        void OnAttack(InputAction.CallbackContext context);
    }
}
