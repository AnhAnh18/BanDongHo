using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TNAShop.Hubs {
    public class CounterHub : Hub {
        private static int counter = 0;

        public override System.Threading.Tasks.Task OnConnected() {
            counter = counter + 1;
            Clients.All.UpdateCount(counter);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnReconnected() {
            counter = counter + 1;
            Clients.All.UpdateCount(counter);
            return base.OnReconnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled) {
            counter = counter - 1;
            Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }
    }
}