### IEnumerable

Create Contact and PhoneBook classes

Create a method Call. It should print "Calling to X. Phone number is Y"

### Program.cs
```cs
Phonebook contacts = new Phonebook();
foreach (Contact contact in contacts)
{
    contact.Call();
}
```
### Contact.cs
```cs
namespace exercise01
{
    internal class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Contact(string name, string phoneNumber) 
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public void Call()
        {
            Console.WriteLine("Calling to {0}. Phone number is {1}", Name, PhoneNumber);
        }
    }
}
```
### Phonebook.cs
```cs
namespace exercise01
{
    internal class Phonebook : IEnumerable<Contact>
    {
        public List<Contact> contacts;

        public Phonebook() {

            contacts = new List<Contact>{
                new Contact("Andre", "435797087"),
                new Contact("Lisa", "435677087"),
                new Contact("Dine", "3457697087"),
                new Contact("Sofi", "4367697087")
            };
        }
        IEnumerator<Contact> IEnumerable<Contact>.GetEnumerator()
        {
            return contacts.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
```
