using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace termii.sdk.Switch.Campaign;

public interface IContact
{
    Task<CResponse> DeleteContact(string contactId);
    Task<CResponse> BulkCreateContact(BulkCreateContactRequestDTO dto);
    Task<CreateContactResponse> CreateContact(CreateContactRequestDTO dto);
    Task<FetchContactsResponse> GetContactsByPhoneBookId(string phoneBookId);
}

public interface IPhoneBook
{
    Task<CResponse> DeletePhoneBook(string phoneBookId);
    Task<CResponse> UpdatePhoneBook(UpdatePhoneBookRequestDTO dto);
    Task<CResponse> CreatePhoneBook(CreatePhoneBookRequestDTO dto);
    Task<FetchPhoneBookResponse> GetPhoneBooks();
}
