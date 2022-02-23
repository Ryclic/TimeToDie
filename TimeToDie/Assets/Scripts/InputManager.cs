    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class InputManager : MonoBehaviour
    {

        public static InputManager instance;
        bool received = true;
        KeyCode curKeyCode;
        string cur;
        TextMeshProUGUI curText;
        TextMeshProUGUI prevTextObject;
        string prevText;

        [SerializeField] private Keybindings keybindings;
        private Dictionary<string,int> keybindDict = new Dictionary<string,int>();

        private void Awake() 
        {
            if (instance==null)
            {
                instance = this;
            } else if (instance != null)
            {
                Destroy(this);
            }
            DontDestroyOnLoad(this);

            string[] nameLoad = {"Forward","Left","Backward","Right","Jump","Sprint","Crouch","Interact"};
            keybindDict.Clear();
            for (int i=0;i<nameLoad.Length;i++) keybindDict.Add(nameLoad[i],i);


            KeybindingActions[] actionLoad = {KeybindingActions.Forward,KeybindingActions.Left,KeybindingActions.Backward,KeybindingActions.Right,KeybindingActions.Jump,KeybindingActions.Sprint,KeybindingActions.Crouch,KeybindingActions.Interact};
            KeyCode[] keycodeLoad = {KeyCode.W,KeyCode.A,KeyCode.S,KeyCode.D,KeyCode.Space,KeyCode.LeftShift,KeyCode.LeftControl,KeyCode.E};
            for (int i=0; i<keybindings.keybindingChecks.Length; i++)
            {
                keybindings.keybindingChecks[i].keybindingAction = actionLoad[i];
                keybindings.keybindingChecks[i].keyCode =  keycodeLoad[i];
            }

        }

        void OnGUI()
        {   
            if (!received)
            {
                Event e = Event.current;
                if (e.isKey)
                {
                    Debug.Log("Setting " + cur + " to " + e.keyCode);
                    curKeyCode = e.keyCode;
                    keybindings.keybindingChecks[keybindDict[cur]].keyCode = curKeyCode;
                    curText.text += e.keyCode;
                    received = true;
                }
            }

        }

        public void ListenForKey(string key)
        {
            if (!received)
            {
                if (!prevText.Equals("")) prevTextObject.text = prevText;
            }
            received = false;
            cur = key;
        }

        public void TakesText(TextMeshProUGUI text)
        {
            prevTextObject = text;
            prevText = text.text;
            text.text = "";
            curText = text;
        }

        public KeyCode GetKeyForAction(KeybindingActions keybindingAction) 
        {
            foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
            {
                if (keybindingCheck.keybindingAction == keybindingAction)
                {
                    return keybindingCheck.keyCode;
                }
            }

            return KeyCode.None;
        }

        public bool GetKeyDown(KeybindingActions key) 
        {
            foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
            {
                if (keybindingCheck.keybindingAction == key)
                {
                    return Input.GetKeyDown(keybindingCheck.keyCode);
                }
            }
            return false;
        }

        public bool GetKey(KeybindingActions key) 
        {
            foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
            {
                if (keybindingCheck.keybindingAction == key)
                {
                    return Input.GetKey(keybindingCheck.keyCode);
                }
            }
            return false;
        }

        public bool GetKeyUp(KeybindingActions key) 
        {
            foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
            {
                if (keybindingCheck.keybindingAction == key)
                {
                    return Input.GetKeyUp(keybindingCheck.keyCode);
                }
            }
            return false;
        }
    }
