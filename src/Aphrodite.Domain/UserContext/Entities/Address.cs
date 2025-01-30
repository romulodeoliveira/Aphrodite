using Aphrodite.Domain.Shared.Entities;
using Aphrodite.Domain.UserContext.Enums;
using Flunt.Validations;

namespace Aphrodite.Domain.UserContext.Entities;

public class Address : BaseEntity
{
    public Address(
        string street, 
        string number, 
        string complement, 
        string district, 
        string city, 
        EBrazilianState state, 
        string zipCode, 
        EAddressType type)
    {
        Street = street;
        Number = number;
        Complement = complement;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
        Type = type;
        
        AddNotifications(
            new Contract<Address>()
                .Requires()
                .IsTrue(street.Length < 30, "Street", "A rua não pode ser maior que 30 caracteres")
                .IsNotNullOrEmpty(street, "Street", "O campo 'rua' não pode estar vazio")
                .IsTrue(number.Length < 10, "Number", "O número não pode ser maior que 10 caracteres")
                .IsNotNullOrEmpty(number, "Number", "O campo 'número' não pode estar vazio")
                .IsTrue(complement.Length < 30, "Complement", "O complemento não pode ser maior que 30 caracteres")
                .IsNotNullOrEmpty(complement, "Complement", "O campo 'complemento' não pode estar vazio")
                .IsTrue(district.Length < 10, "District", "O distrito não pode ser maior que 10 caracteres")
                .IsNotNullOrEmpty(district, "District", "O campo 'distrito' não pode estar vazio")
                .IsTrue(city.Length < 30, "City", "A cidade não pode ser maior que 30 caracteres")
                .IsNotNullOrEmpty(city, "City", "O campo 'cidade' não pode estar vazio")
                .IsTrue(Enum.IsDefined(typeof(EBrazilianState), state), "State", "O estado fornecido é inválido")
                .IsTrue(zipCode.Length == 8, "ZipCode", "O código postal deve conter 8 caracteres")
                .IsNotNullOrEmpty(zipCode, "ZipCode", "O campo 'código postal' não pode estar vazio")
                .IsTrue(Enum.IsDefined(typeof(EAddressType), type), "Type", "O tipo de endereço fornecido é inválido")
            );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string District { get; private set; }
    public string City { get; private set; }
    public EBrazilianState State { get; private set; }
    public string ZipCode { get; private set; }
    public EAddressType Type { get; private set; }

    public override string ToString()
    {
        return $"{Street}, {Number} - {City}/{State}";
    }

    public void UpdateType(EAddressType newType)
    {
        Type = newType; 
        
        AddNotifications(
            new Contract<Address>()
                .Requires()
                .IsTrue(Enum.IsDefined(typeof(EAddressType), newType), "Type", "O tipo de endereço fornecido é inválido")
        );
    }
    
    public void UpdateAddress(string street, 
        string number, 
        string complement, 
        string district, 
        string city, 
        EBrazilianState state, 
        string zipCode, 
        EAddressType type)
    {
        Street = street;
        Number = number;
        Complement = complement;
        District = district;
        City = city;
        State = state;
        ZipCode = zipCode;
        Type = type;
        
        AddNotifications(
            new Contract<Address>()
                .Requires()
                .IsTrue(street.Length < 30, "Street", "A rua não pode ser maior que 30 caracteres")
                .IsNotNullOrEmpty(street, "Street", "O campo 'rua' não pode estar vazio")
                .IsTrue(number.Length < 10, "Number", "O número não pode ser maior que 10 caracteres")
                .IsNotNullOrEmpty(number, "Number", "O campo 'número' não pode estar vazio")
                .IsTrue(complement.Length < 30, "Complement", "O complemento não pode ser maior que 30 caracteres")
                .IsNotNullOrEmpty(complement, "Complement", "O campo 'complemento' não pode estar vazio")
                .IsTrue(district.Length < 10, "District", "O distrito não pode ser maior que 10 caracteres")
                .IsNotNullOrEmpty(district, "District", "O campo 'distrito' não pode estar vazio")
                .IsTrue(city.Length < 30, "City", "A cidade não pode ser maior que 30 caracteres")
                .IsNotNullOrEmpty(city, "City", "O campo 'cidade' não pode estar vazio")
                .IsTrue(Enum.IsDefined(typeof(EBrazilianState), state), "State", "O estado fornecido é inválido")
                .IsTrue(zipCode.Length == 8, "ZipCode", "O código postal deve conter 8 caracteres")
                .IsNotNullOrEmpty(zipCode, "ZipCode", "O campo 'código postal' não pode estar vazio")
                .IsTrue(Enum.IsDefined(typeof(EAddressType), type), "Type", "O tipo de endereço fornecido é inválido")
        );
    }
}