using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories {
    public class XboxRemote : Remote {
        private readonly string _remoteType;
        private string _company;

        public XboxRemote(bool wired, bool batteries, string company) {
            _remoteType = "Xbox";
            _company = company;
            this.Wired = wired;
            this.Batteries = batteries;
        }

        public override string RemoteType {
            get { return _remoteType; }
        }

        public override string Company {
            get { return _company; }
            set { _company = value; }
        }
    }
}
