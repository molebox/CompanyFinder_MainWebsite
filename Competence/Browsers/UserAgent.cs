using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Browsers
{
    /// <summary>
    /// User Agent class to represent the user agent from the browser
    /// </summary>
    public class UserAgent
    {
        private string _userAgent;

        private ClientBrowser _browser;
        /// <summary>
        /// Browser property
        /// </summary>
        public ClientBrowser Browser
        {
            get
            {
                if (_browser == null)
                {
                    _browser = new ClientBrowser(_userAgent);
                }
                return _browser;
            }
        }

        private ClientOS _os;
        /// <summary>
        /// OS property
        /// </summary>
        public ClientOS OS
        {
            get
            {
                if (_os == null)
                {
                    _os = new ClientOS(_userAgent);
                }
                return _os;
            }
        }
        /// <summary>
        /// User Agent property
        /// </summary>
        /// <param name="userAgent"></param>
        public UserAgent(string userAgent)
        {
            _userAgent = userAgent;
        }
    }
}
