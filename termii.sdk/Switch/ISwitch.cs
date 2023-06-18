using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace termii.sdk.Switch
{
    public interface ISwitch
    {
        Task<RegisterSenderIdResponse> RegisterSenderId(RegisterSenderIdRequestDTO dto);
        Task<GetSenderIdResponse> GetSenderId();
        Task<SendMessageResponse> SendMessage(SendMessageRequestDTO dto);
    }
}
