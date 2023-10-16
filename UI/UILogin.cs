using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarylProductions
{
    public class UILogin: MonoBehaviour
    {
        public void UpdateUsername(string _username)
        {
            PlayfabManager.Instance.username = _username;
        }
        public void UpdatePassword(string _password)
        {
            PlayfabManager.Instance.password = _password;
        }

        public void Login()
        {
            PlayfabManager.Instance.Login();
        }
    }
}
