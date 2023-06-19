using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace termii.sdk.Switch
{
    public interface ITemplate
    {
        Task<TemplateResponse> Send(TemplateRequestDTO dto);
    }

    public interface INumber
    {
        Task<NumberMessageResponse> Send(NumberMessageRequestDTO dto);
    }

    public interface IMessaging
    {
        Task<BulkMessageResponse> Bulk(BulkMessageRequestDTO dto);
        Task<SendMessageResponse> Send(SendMessageRequestDTO dto);
    }

    public interface ISender
    {
        Task<RegisterSenderIdResponse> RegisterSenderId(RegisterSenderIdRequestDTO dto);
        Task<GetSenderIdResponse> GetSenderId();
    }
}
