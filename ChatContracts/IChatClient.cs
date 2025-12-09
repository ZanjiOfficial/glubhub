using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatContracts
{
    public interface IChatClient
    {
        Task RecieveSystemMessage(string message);
        Task UpdateUserList(List<ConnectedUser> users);

        Task RecieveMessage(string fromUserId, string fromConnectionId, string message);
    }
}
