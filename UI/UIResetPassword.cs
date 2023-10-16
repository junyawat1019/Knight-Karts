using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarylProductions
{
    public class UIResetPassword : MonoBehaviour
    {
        public void UpdateEmailAddress(string _emailAddress)
        {
            PlayfabManager.Instance.emailAddress = _emailAddress;
        }

        public void SendRecovery()
        {
            PlayfabManager.Instance.SendRecovery();
        }
    }
}
