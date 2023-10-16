using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarylProductions 
{
    public class UIRegister : MonoBehaviour
    {
        public void UpdateUsername(string _username)
        {
            PlayfabManager.Instance.username = _username;
        }
        public void UpdatePassword(string _password)
        {
            PlayfabManager.Instance.password = _password;
        }
        public void UpdateEmailAddress(string _emailAddress)
        {
            PlayfabManager.Instance.emailAddress = _emailAddress;
        }

        public void RegisterAccount()
        {
            PlayfabManager.Instance.RegisterAccount();
        }
    }
}
