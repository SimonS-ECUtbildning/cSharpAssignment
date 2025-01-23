using System.Diagnostics;
using System.Text.Json;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    private List<Contact> _contacts = [];

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public bool CreateContact(Contact contact)
    {
        contact.Id = IdGenerator.GenerateId();
        _contacts.Add(contact);
        return true;
    }

    public IEnumerable<Contact> GetContacts()
    {
        GetListFromFile();
        return _contacts;
    }

    public void GetListFromFile()
    {
        try
        {
            var json = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(json))
            {
                _contacts = JsonSerializer.Deserialize<List<Contact>>(json)!;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            _contacts = [];
        }
    }
}