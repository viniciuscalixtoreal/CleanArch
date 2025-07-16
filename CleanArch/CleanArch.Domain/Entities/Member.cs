using CleanArch.Domain.Validation;
using System.Text.Json.Serialization;

namespace CleanArch.Domain.Entities
{
    public sealed class Member : Entity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Gender { get; private set; }
        public string? Email { get; private set; }
        public bool? IsActive { get; private set; }

        public Member(string firstName, string lastName, string gender, string email, bool? activate)
        {
            ValidateDomain(firstName, lastName, gender, email, activate);
        }

        public Member() { }

        [JsonConstructor]
        public Member(int id, string firstName, string lastName, string gender, string email, bool? activate)
        {
            DomainValidation.When(id < 0, "Invalid Id Value");
            Id = id;

            ValidateDomain(firstName, lastName, gender, email, activate);
        }

        public void Update(string firstName, string lastName, string gender, string email, bool? activate)
        {
            ValidateDomain(firstName, lastName, gender, email, activate);
        }

        private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? activate)
        {
            DomainValidation.When(string.IsNullOrEmpty(firstName),
                "Invalid name. FirstName is required.");

            DomainValidation.When(firstName.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainValidation.When(string.IsNullOrEmpty(lastName),
                "Invalid name. LastName is required.");

            DomainValidation.When(lastName.Length < 3,
                "Invalid lastName, too short, minimum 3 characters.");

            DomainValidation.When(email?.Length > 250,
                "Invalid email, too long, maximum 250 characters.");

            DomainValidation.When(email?.Length < 6,
                "Invalid email, too short, minimum 6 characters.");

            DomainValidation.When(!activate.HasValue,
                "Must define activity.");

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = activate;
        }
    }
}
